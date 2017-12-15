using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace namentlitch
{
    using System.IO;
    using System.Drawing;

    public partial class frmNamentlitch : Form
    {
        string _pathToGetImagesFrom = "";
        int _prevSelectedIndex = -1,_lastSlectedIndex = -1;
        List<Bitmap> thumbNails = new List<Bitmap>();

        public int PrevSelectedIndex
        {
            get { return _prevSelectedIndex; }
            set { _prevSelectedIndex = value; }
        }

        public string PathToGetImagesFrom
        {
            get { return _pathToGetImagesFrom; }
            set { _pathToGetImagesFrom = value; }
        }

        public int LastSelectedFolderIndex
        {
            get { return _lastSlectedIndex; }
            set { _lastSlectedIndex = value; }
        }

        public frmNamentlitch(string pathToGetImagesFrom)
        {
            InitializeComponent();

            if (!Directory.Exists(pathToGetImagesFrom))
                pathToGetImagesFrom = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);

            this.PathToGetImagesFrom = pathToGetImagesFrom;

            RefreshImageList();
        }

        public frmNamentlitch()
        {
            InitializeComponent();

            PathToGetImagesFrom = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);

            RefreshImageList();
        }

        private void RotateSelectedColors(int nextSelectedItem)
        {
            if ((lstImageList.Items.Count <= PrevSelectedIndex))
                return;

            if (PrevSelectedIndex > -1)
                lstImageList.Items[PrevSelectedIndex].ForeColor = Color.Black;

            lstImageList.Items[nextSelectedItem].ForeColor = Color.Red;

            PrevSelectedIndex = nextSelectedItem;
        }

        private void SelectFirstImageInList()
        {
            if ((null == lstImageList)||( lstImageList.Items.Count <= 0))
                return;

            int i = 0;
            foreach (ListViewItem item in lstImageList.Items)
            {
                if (item.ImageIndex != 0)
                    break;

                ++i;
            }

            //only folders no images.
            if (i >= lstImageList.Items.Count)
                return;

            SelectItemInList(i);

            lstImageList.Items[i].ForeColor = Color.Red;
            PrevSelectedIndex = i;
        }

        private void SelectItemInList(int index)
        {
            if (index >= lstImageList.Items.Count)
                return;

            //do not select if this item is a folder.
            if (lstImageList.Items[index].ImageIndex == 0)
                return;

            lstImageList.Items[index].Selected = true;

            RotateSelectedColors(index);

            txtName.Select();

            txtName.SelectAll();

            //Set the background image here.
            Bitmap img = null;
            string filename = null;
            int imgIndex = 0;

            if (thumbNails.Count <= lstImageList.Items[index].Index)
                return;

            img = thumbNails[lstImageList.Items[index].Index];

            filename = lstImageList.Items[index].Text;
            imgIndex = lstImageList.Items[index].Index;

            //if (0 < lstImageList.SelectedItems.Count)
            //{
            //    if (thumbNails.Count <= lstImageList.SelectedItems[0].Index)
            //        return;

            //    img = thumbNails[lstImageList.SelectedItems[0].Index];

            //    filename = lstImageList.SelectedItems[0].Text;
            //    imgIndex = lstImageList.SelectedItems[0].Index;
            //}
            //else
            //{
            //    imgIndex = 0;
            //    filename = lstImageList.Items[0].Text;
            //}

            if (null == img)
            {
                string file = Path.Combine(PathToGetImagesFrom, filename);
                img = GetThumbNailForImage(file);
                thumbNails[imgIndex] = img;
            }

            pctBox.BackgroundImage = img;
        }

        private Bitmap GetThumbNailForImage(string filename)
        {
            try
            {
                System.Drawing.Size thumbBoundingBox = pctBox.Size;

                Image img = Image.FromFile(filename, true);
                Bitmap thumbNailImage;

                //if the image is smaller than the thumbnail bounding box then just return the image.
                if ((img.Width < thumbBoundingBox.Width) && (img.Height < thumbBoundingBox.Height))
                {
                    thumbNailImage = (Bitmap)img;
                    return thumbNailImage;
                }

                bool HeightBiggerThanWidth = (img.Width < img.Height) ? true : false;
                float aspectRatio = (float)((float)img.Height / (float)img.Width);

                if (HeightBiggerThanWidth)
                {
                    thumbBoundingBox.Height = thumbBoundingBox.Height;

                    thumbBoundingBox.Width = (int)((float)thumbBoundingBox.Height / aspectRatio);

                    //this provides us with a fudge factor if the height is still a little bit bigger than the bounding box.
                    if (thumbBoundingBox.Width > thumbBoundingBox.Width)
                        thumbBoundingBox.Width = thumbBoundingBox.Width;
                }
                else
                {
                    thumbBoundingBox.Height = (int)((float)thumbBoundingBox.Width * aspectRatio);

                    //this provides us with a fudge factor if the height is still a little bit bigger than the bounding box.
                    if (thumbBoundingBox.Height > thumbBoundingBox.Height)
                        thumbBoundingBox.Height = thumbBoundingBox.Height;
                }

                thumbNailImage = new Bitmap(thumbBoundingBox.Width, thumbBoundingBox.Height);

                Graphics g = Graphics.FromImage(thumbNailImage);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, thumbNailImage.Width, thumbNailImage.Height);
                img.Dispose();

                //thumbNailImage = (Bitmap)img.GetThumbnailImage(thumbBoundingBox.Width, thumbBoundingBox.Height, null, new IntPtr(0));
                return thumbNailImage;
            }
            catch (OutOfMemoryException)
            {
            }

            return null;
        }

        public static bool IsFileAnImageFile(string file)
        {
            try
            {
                string extension = Path.GetFileName(file).Replace(Path.GetFileNameWithoutExtension(file), "").ToLowerInvariant().TrimStart('.');

                switch (extension)
                {
                    case "jpg":
                    case "png":
                    case "jpeg":
                    case "jfif":
                    case "tiff":
                    case "exif":
                    case "raw":
                    case "gif":
                    case "ppm":
                    case "pgm":
                    case "pbm":
                    case "pnm":
                    case "webp":
                    case "cgm":
                    case "svg":
                        return true;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                //if we have weird file names (like extension only) then just eat them
            }

            return false;
        }

        private void AddImagesInDirToListView(string path)
        {
            string[] files = Directory.GetFiles(path, "*");

            foreach (string file in files)
            {
                if ((null == file) || (0 == file.Length))
                    continue;

                if (!IsFileAnImageFile(file))
                    continue;

                ListViewItem item = new ListViewItem(Path.GetFileName(file));

                item.ImageIndex = 1;

                lstImageList.Items.Add(item);

                thumbNails.Add(null);
            }
        }

        private void AddFoldersInDirToListView(string path)
        {
            string[] dirs = Directory.GetDirectories(path);

            string itemName = "";

            foreach (string dir in dirs)
            {
                if ((null == dirs) || (0 == dirs.Length))
                    continue;
                
                itemName = dir.Replace(Path.GetDirectoryName(dir), "");

                if (itemName.StartsWith("\\")&&(itemName.Length >0))
                    itemName = itemName.Substring(1);

                ListViewItem item = new ListViewItem(itemName);

                item.ImageIndex = 0;

                lstImageList.Items.Add(item);

                thumbNails.Add(null);
            }
        }

        private void RefreshImageList()
        {
            if ((!Directory.Exists(PathToGetImagesFrom)||(null == PathToGetImagesFrom) || (0 == PathToGetImagesFrom.Length)))
                return;

            thumbNails.Clear();

            lstImageList.Clear();

            AddFoldersInDirToListView(PathToGetImagesFrom);

            AddImagesInDirToListView(PathToGetImagesFrom);

            SelectFirstImageInList();

            textBoxSrc.Text = PathToGetImagesFrom;
        }

        private string RemoveInvalidCharsFromFileName(string fileName)
        {
            char[] invalidChars = Path.GetInvalidPathChars();

            fileName = fileName.Replace("\\", "");

            for(int i=fileName.Length-1; i >= 0; i--)
            {
                if (Array.IndexOf(invalidChars, fileName[i]) >= 0)
                    fileName = fileName.Remove(i, 1);
            }

            return fileName;
        }

        private bool ChangeFileName()
        {
            if (lstImageList.Items.Count == 0)
                return false;

            if (lstImageList.SelectedItems.Count == 0)
                return false;

            //Get the new text added.
            bool nameUpdated = false;
            string oldName = lstImageList.SelectedItems[0].Text;
            string extention = oldName.Replace(Path.GetFileNameWithoutExtension(oldName), "");
            string newName = txtName.Text;
            int currentIndex = lstImageList.SelectedItems[0].Index;

            newName = RemoveInvalidCharsFromFileName(newName);

            //Verify we dont get a name like .jpg.jpg
            if (newName.ToLower().EndsWith(extention.ToLower()))
            {
                string tempExtention = Path.GetExtension(newName);
                newName = newName.Replace(tempExtention, "");
            }

            //verfy they are not trying to change the file extension
            if (newName.Contains("."))
            {
                MessageBox.Show("Cannot change file extention from " + extention+".");
                txtName.Select();
                txtName.SelectAll();
                return false;
            }

            //newName = newName + extention.ToLower();
            if (!(newName+extention).Equals(oldName, StringComparison.OrdinalIgnoreCase))
            {
                //Do not overwrite file names
                if (File.Exists(Path.Combine(PathToGetImagesFrom, newName+extention)))
                {
                    int digit = 0;
                    string nameWithOutDigit = SeparateNumberFromName(newName, out digit);

                    while (File.Exists(Path.Combine(PathToGetImagesFrom, nameWithOutDigit + digit + extention)))
                    {
                        ++digit;
                    }

                    DialogResult result = MessageBox.Show("This name is already taken by another photo.  Do you want to call it " + nameWithOutDigit + digit + extention, "File Exists!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No)
                    {
                        txtName.Select();
                        txtName.SelectAll();
                        return false;
                    }
                    newName = nameWithOutDigit + digit;
                }

                //change the text of the file.
                File.Move(Path.Combine(PathToGetImagesFrom, oldName), Path.Combine(PathToGetImagesFrom, newName+extention));

                //change the text in the list
                lstImageList.SelectedItems[0].Text = newName+extention;

                //update the thumbnail image in the list.
                thumbNails[currentIndex] = GetThumbNailForImage(Path.Combine(PathToGetImagesFrom, newName+extention));
                nameUpdated = true;
            }

            //Move to the next Index;
            if (currentIndex + 1 < lstImageList.Items.Count)
                SelectItemInList(++currentIndex);
            else
                SelectItemInList(0);

            return nameUpdated;
        }

        private void ChangePath(string path)
        {
            PathToGetImagesFrom = path;

            txtName.Clear();

            RefreshImageList();

            if (lstImageList.Items.Count <= 0)
                pctBox.Hide();
            else
                pctBox.Show();
        }

        private void RotateCurrentImageImage(RotateFlipType flipType)
        {
            if ((null == lstImageList)||(null == lstImageList.SelectedItems)||(0 == lstImageList.SelectedItems.Count))
                return;

            //Get the current image name
            int imgIndex = 0;
            string CurrentFileName = lstImageList.SelectedItems[0].Text;
            string currentPath = this.PathToGetImagesFrom;
            string file = Path.Combine(currentPath, CurrentFileName);

            if (!File.Exists(file))
                return;

            //Rotate the file
            Image temp = Image.FromFile(file, true);
            temp.RotateFlip(flipType);

            //Save the file
            temp.Save(file);

            //set the stored thumbnail in the list.
            imgIndex = lstImageList.SelectedItems[0].Index;
            Image img = GetThumbNailForImage(file);
            thumbNails[imgIndex] = (Bitmap)img;

            if (null == img)
                return;

            //Reload the displayed bitmap.
            pctBox.BackgroundImage = img;

            txtName.Focus();
        }

        private void btnUpFolder_Click(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(PathToGetImagesFrom);

            ChangePath(info.Parent.FullName);

            //PrevSelectedIndex = -1;
            LastSelectedFolderIndex = -1;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.SelectedPath = PathToGetImagesFrom;

            dlg.ShowDialog();

            string path = dlg.SelectedPath ;

            if (PathToGetImagesFrom.ToLower().Trim() == path.ToLower().Trim())
                return;

            if ((!Directory.Exists(path))||(null == path)||(0 == path.Length))
                return;

            ChangePath(path);

            PrevSelectedIndex = -1;
            LastSelectedFolderIndex = -1;
        }

        private void lstImageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((null == lstImageList.SelectedItems) || (0 == lstImageList.SelectedItems.Count))
                return;

            if (lstImageList.SelectedItems[0].ImageIndex == 0)
            {
                LastSelectedFolderIndex = lstImageList.SelectedItems[0].Index;

                if (PrevSelectedIndex != -1)
                    SelectItemInList(PrevSelectedIndex);
                return;
            }

            //Change the name edit box to be the name of the file selected.
            txtName.Text = Path.GetFileNameWithoutExtension(lstImageList.SelectedItems[0].Text);

            RotateSelectedColors(lstImageList.SelectedItems[0].Index);
        }

        private void lstImageList_MouseUp(object sender, MouseEventArgs e)
        {
            if (lstImageList.SelectedItems.Count <= 0)
                return;

            SelectItemInList(lstImageList.SelectedItems[0].Index);
        }

        private void lstImageList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((LastSelectedFolderIndex == -1) || (LastSelectedFolderIndex >= lstImageList.Items.Count))
            {
                LastSelectedFolderIndex = -1;
                return;
            }

            string path = Path.Combine(PathToGetImagesFrom, lstImageList.Items[LastSelectedFolderIndex].Text);

            if ((null == path) || (0 == path.Length) || (!Directory.Exists(path)))
            {
                LastSelectedFolderIndex = -1;
                return;
            }

            ChangePath(path);

            PrevSelectedIndex = -1;
            LastSelectedFolderIndex = -1;
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && e.Control)
            {
                buttonNext_Click(null, null);

                return;
            }
            else if (e.KeyCode == Keys.P && e.Control)
            {
                buttonPrev_Click(null, null);

                return;
            }
        }

        private string SeparateNumberFromName(string name,out int digit)
        {
            digit = 1;
            int startOfDigits = name.Length - 1;
            int digitCount = 0;

            for (int i = name.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(name[i]))
                {
                    ++digitCount;
                    startOfDigits--;
                }
                else
                    break;
            }

            if (0 == digitCount)
                return name;

            string newName = name.Substring(0, startOfDigits+1);
            string digitStr = name.Substring(startOfDigits+1);

            Int32.TryParse(digitStr, out digit);

            return newName;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            string newName = this.txtName.Text;

            if (ChangeFileName())
            {
                if (this.txtName.AutoCompleteCustomSource.Count >= 100)
                    this.txtName.AutoCompleteCustomSource.RemoveAt(99);

                int digit = 0;
                string nameToAdd = SeparateNumberFromName(newName, out digit);

                string extention = lstImageList.SelectedItems[0].Text.Replace(Path.GetFileNameWithoutExtension(lstImageList.SelectedItems[0].Text), "");

                while (File.Exists(Path.Combine(this.PathToGetImagesFrom, nameToAdd + digit + extention)))
                {
                    ++digit;
                }

                if (this.txtName.AutoCompleteCustomSource.Contains(nameToAdd + (digit-1)))
                    this.txtName.AutoCompleteCustomSource.Remove(nameToAdd + (digit - 1));

                if (this.txtName.AutoCompleteCustomSource.Contains(newName))
                    this.txtName.AutoCompleteCustomSource.Remove(newName);

                this.txtName.AutoCompleteCustomSource.Add(nameToAdd + digit);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ChangeFileName();
        }

        private void btnRotateImageRight_Click(object sender, EventArgs e)
        {
            //Rotate to the right 90 degree's
            RotateCurrentImageImage(RotateFlipType.Rotate90FlipNone);
        }

        private void btnRotateImageLeft_Click(object sender, EventArgs e)
        {
            //Rotate to the left 90 degree's
            RotateCurrentImageImage(RotateFlipType.Rotate270FlipNone);
        }

        private void S_Click(object sender, EventArgs e)
        {
            string[] imageFiles = Directory.GetFiles(_pathToGetImagesFrom, "*.jpg");

            foreach (string image in imageFiles)
            {
                ShrinkImage(image);
            }
        }

        private void ShrinkImage(string image)
        {
            Bitmap img = SetUpThumbNailImage(new Size(850, 1150), true, image);
        }

        public static int LastImageWidth;
        public static int LastImageHeight;

        public static Bitmap SetUpThumbNailImage(System.Drawing.Size thumbBoundingBox, bool KeepAspectRatio, string filename)
        {
            try
            {
                Image img = Image.FromFile(filename, true);
                Bitmap thumbNailImage;

                LastImageHeight = img.Height;
                LastImageWidth = img.Width;

                //if the image is smaller than the thumbnail bounding box then just return the image.
                if ((img.Width < thumbBoundingBox.Width) && (img.Height < thumbBoundingBox.Height))
                {
                    thumbNailImage = (Bitmap)img;
                    return thumbNailImage;
                }

                if (!KeepAspectRatio)
                {
                    thumbNailImage = (Bitmap)img.GetThumbnailImage(thumbBoundingBox.Width, thumbBoundingBox.Height, null, new IntPtr(0));
                    return thumbNailImage;
                }

                bool HeightBiggerThanWidth = (img.Width < img.Height) ? true : false;
                float aspectRatio = (float)((float)img.Height / (float)img.Width);

                if (HeightBiggerThanWidth)
                {
                    int temp = thumbBoundingBox.Height;
                    thumbBoundingBox.Height = thumbBoundingBox.Width;
                    thumbBoundingBox.Width = temp;

                    //thumbBoundingBox.Width = (int)((float)thumbBoundingBox.Height / aspectRatio);

                    //this provides us with a fudge factor if the height is still a little bit bigger than the bounding box.
                    //if (thumbBoundingBox.Width > thumbBoundingBox.Width)
                    //    thumbBoundingBox.Width = thumbBoundingBox.Width;
                }
                //else
                //{
                thumbBoundingBox.Height = (int)((float)thumbBoundingBox.Width * aspectRatio);

                //this provides us with a fudge factor if the height is still a little bit bigger than the bounding box.
                if (thumbBoundingBox.Height > thumbBoundingBox.Height)
                    thumbBoundingBox.Height = thumbBoundingBox.Height;
                //}

                //if (((img.Height == thumbBoundingBox.Height) && (img.Width == thumbBoundingBox.Width)) || (filename.Contains("." + thumbBoundingBox.Height + "x" + thumbBoundingBox.Width))) 
                //    return null;

                thumbNailImage = new Bitmap(thumbBoundingBox.Width, thumbBoundingBox.Height);

                Graphics g = Graphics.FromImage(thumbNailImage);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, thumbNailImage.Width, thumbNailImage.Height);
                img.Dispose();

                //thumbNailImage = (Bitmap)img.GetThumbnailImage(thumbBoundingBox.Width, thumbBoundingBox.Height, null, new IntPtr(0));
                return thumbNailImage;
            }
            catch (OutOfMemoryException)
            {
            }

            return null;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            int index = lstImageList.SelectedItems[0].Index;

            if (index + 1 < lstImageList.Items.Count)
                SelectItemInList(++index);
            else
                SelectFirstImageInList();

            return;
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            int index = lstImageList.SelectedItems[0].Index;

            if ((index - 1 >= 0) && (lstImageList.Items[index - 1].ImageIndex != 0))
                SelectItemInList(--index);
            else
                SelectItemInList(lstImageList.Items.Count - 1);

            return;
        }

    }
}