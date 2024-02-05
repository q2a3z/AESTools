using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Kumas_SavadataTool
{
    public partial class FormMain : Form
    {
        string clickedNode;
        string sEditFullPath;
        string sEditKey;
        string sImportFile;
        private Dictionary<string, string> saveDictionary;

        MenuItem editMenuItem = new MenuItem("編集");
        ContextMenu mnu = new ContextMenu();

        public FormMain()
        {
            InitializeComponent();

            this.txtAesKey.Text = Properties.Settings.Default.sAseKey;

            btnSave.Visible = false;
            
            this.pnlDragAndDrop.DragDrop += new
                System.Windows.Forms.DragEventHandler(this.pnlDragAndDrop_DragDrop);
            this.pnlDragAndDrop.DragEnter += new
                System.Windows.Forms.DragEventHandler(this.pnlDragAndDrop_DragEnter);

            mnu.MenuItems.Add(editMenuItem);
            editMenuItem.Click += new EventHandler(editMenuItem_Click);
        }

        private void pnlDragAndDrop_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pnlDragAndDrop_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            sImportFile = s[0];
            loadJsonFile(sImportFile);

            //AesManager.AesEncrypt(Encoding.UTF8.GetBytes("ddsdsdsds"),"ddsdsdsds");
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void plTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Save File|*.savedata" +
                                        "|All File|*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sImportFile = openFileDialog.FileName;
                    loadJsonFile(sImportFile);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var serialDict = new SerializationSaveDate<string, string>(saveDictionary);
            serialDict.OnBeforeSerialize();
            // セーブデータをJSON形式の文字列に変換
            var jsonString = JsonConvert.SerializeObject(serialDict, Formatting.Indented);
            File.WriteAllText(sImportFile, jsonString);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
            // AES暗号化
            byte[] arrEncrypted = AesManager.AesEncrypt(bytes, txtAesKey.Text);
            // 指定したパスにファイルを作成
            FileStream file = new FileStream(sImportFile, FileMode.Create, FileAccess.Write);

            //ファイルに保存する
            try
            {
                // ファイルに保存
                file.Write(arrEncrypted, 0, arrEncrypted.Length);

            }
            finally
            {
                // ファイルを閉じる
                if (file != null)
                {
                    file.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.sAseKey = this.txtAesKey.Text;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        void editMenuItem_Click(object sender, EventArgs e)
        {
            sEditKey = Regex.Split(sEditFullPath, @"\\").First(); // スペースで文字列を分割する
            string[] result = Regex.Split(sEditFullPath, @"\\"); // スペースで文字列を分割する
            

            saveDictionary.TryGetValue(sEditKey, out var strJson);
            var data = (JObject)JsonConvert.DeserializeObject(strJson);
            //var timeZone = data[clickedNode].Value<string>();
            foreach (string match in result)
            {
                if (data.TryGetValue(clickedNode, out JToken nameToken))
                {
                    var name = nameToken;
                    //Console.WriteLine($"Name: {name}");
                }
                //var timeZone = data[clickedNode].Value<string>();
                //Console.WriteLine("'{0}'", match);
            }

            //ToJson(treeViewJson);
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            treeViewJson.SelectedNode.Text = editTextBox.Text;
            TreeToJson(treeViewJson);
        }
        private void treeViewJson_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewJson.SelectedNode.Nodes.Count == 0)
                editTextBox.Text = treeViewJson.SelectedNode.Text;
        }

        private void treeViewJson_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                clickedNode = e.Node.Text;
                sEditFullPath = e.Node.FullPath;
                var tt = treeViewJson.SelectedNode;
                mnu.Show(treeViewJson, e.Location);
            }
        }
        #region JSON File Function
        private void loadJsonFile(string sFile) 
        {
            pnlDragAndDrop.Visible = false;
            panel1.Visible = true;
            btnSave.Visible = true;

            // ツリービューをクリア
            treeViewJson.Nodes.Clear();
            try
            {
                // ファイル読み込み
                byte[] arrRead = File.ReadAllBytes(sFile);
                // 復号化
                byte[] arrDecrypt = AesManager.AesDecrypt(arrRead, txtAesKey.Text);
                // byte配列を文字列に変換
                string decryptStr = Encoding.UTF8.GetString(arrDecrypt);

                // JSONデータを解析してツリービューに表示
                var sDict = JsonConvert.DeserializeObject<SerializationSaveDate<string, string>>(decryptStr);

                sDict.OnAfterDeserialize();
                saveDictionary = sDict.ToDictionary();
                List<string> keyList = saveDictionary.Keys.ToList();

                foreach (string sKey in keyList)
                {
                    saveDictionary.TryGetValue(sKey, out var strJson);
                    //perseJsonData(strJson, sKey);
                    loadTreeView(strJson, sKey);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("JSONファイルの読み込みエラー: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buildTreeView(TreeNode node, JObject jsonObject)
        {
            foreach (var property in jsonObject.Properties())
            {
                string propertyName = property.Name;
                JToken propertyValue = property.Value;
                TreeNode newNode = new TreeNode(propertyName);
                newNode.Tag = property.Name;
                newNode.Name = property.Name;
                newNode.Text = property.Name;

                if (propertyValue.Type == JTokenType.Object)
                {
                    buildTreeView(newNode, (JObject)propertyValue);
                }
                else if (propertyValue.Type == JTokenType.Array)
                {
                    int index = 0;
                    foreach (var item in (JArray)propertyValue)
                    {
                        TreeNode arrayNode = new TreeNode($"[{index}]");
                        if (item.Type == JTokenType.Object)
                        {
                            buildTreeView(arrayNode, (JObject)item);
                        }
                        else
                        {
                            arrayNode.Nodes.Add(item.ToString());
                        }
                        newNode.Tag = "JArray";
                        newNode.Name = property.Name;
                        newNode.Text = property.Name;
                        newNode.Nodes.Add(arrayNode);
                        index++;
                    }
                }
                else
                {
                    newNode.Nodes.Add(propertyValue.ToString());
                }

                if (node == null)
                {
                    treeViewJson.Nodes.Add(newNode);
                }
                else
                {
                    node.Nodes.Add(newNode);
                }
            }
        }

        private void loadTreeView(string jsonData, string sKey)
        {
            treeViewJson.BeginUpdate();

            JObject json = JObject.Parse(jsonData);

            // recursively add the JSON nodes to the treeview.
            TreeNode tn = new TreeNode();
            tn.Tag = "Key";
            tn.Name = sKey;
            tn.Text = sKey;
            treeViewJson.Nodes.Add(tn);

            buildTreeView(tn, json);
            // MouseClickイベントの追加
            //treeViewJson.NodeMouseClick += treeViewJson_NodeMouseClick;
            treeViewJson.ExpandAll();

            treeViewJson.EndUpdate();
        }

        public void TreeToJson(TreeView treeView)
        {
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                JObject json = new JObject();
                recurseTree(n, json, "");
                saveDictionary[n.Text] = json.ToString(Newtonsoft.Json.Formatting.None);
            }
        }

        private void recurseTree(TreeNode treeNode, JObject json, string tag)
        {
            //string tag;
            if (treeNode.Tag == null)
            {

            }
            else
            {
                if (treeNode.Tag.ToString() == "JArray")
                {
                    JArray jarrayObj = new JArray();
                    foreach (TreeNode tn in treeNode.Nodes)
                    {
                        JObject jsonArray = new JObject();
                        recurseTree(tn, jsonArray, tag);
                        jarrayObj.Add(jsonArray);
                    }
                    json.Add(treeNode.Text, jarrayObj);
                    return;
                }

                tag = treeNode.Tag.ToString();
                if (tag.Length == 0)
                {
                    tag = treeNode.Text;
                }
            }

            int numChildren = treeNode.Nodes.Count;
            if (numChildren == 0)
            {
                json.Add(tag, treeNode.Text);
                return;
            }

            foreach (TreeNode tn in treeNode.Nodes)
            {
                recurseTree(tn, json, tag);
            }
        }
        #endregion
    }
}
