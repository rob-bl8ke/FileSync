using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSync
{
    public class ListviewHelper
    {
        public static int SortingColumn { get; set; }

        public static void SortColumn(ListView listView, int columnIndex)
        {
            if (columnIndex != SortingColumn)
            {
                // Set the sort column to the new column.
                SortingColumn = columnIndex;
                // Set the sort order to ascending by default.
                listView.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listView.Sorting == SortOrder.Ascending)
                    listView.Sorting = SortOrder.Descending;
                else
                    listView.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            //this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column,
            //                                     listView1.Sorting);
            listView.ListViewItemSorter = new ListViewItemComparer(columnIndex, listView.Sorting);
            listView.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
        }

        public static void UpdateListviewItems(ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                SyncItem syncItem = item.Tag as SyncItem;
                item.Text = syncItem.TargetTitle;
                item.SubItems[1].Text = syncItem.TargetFile;
                item.SubItems[2].Text = syncItem.WorkingFile;
            }
        }

        public static void CreateListviewItem(ListView listView, ImageList imageList, SyncItem item, bool select = false)
        {
            string ext = Path.GetExtension(item.TargetFile);
            if (!imageList.Images.ContainsKey(ext))
            {
                imageList.Images.Add(ext, item.GetAssociatedIcon());
            }

            ListViewItem listItem = new ListViewItem();
            listItem.Tag = item;
            listItem.Text = item.TargetTitle;
            listItem.ImageKey = AddImageAssociation(imageList, item);
                        
            listItem.SubItems.Add(new ListViewItem.ListViewSubItem(listItem, item.TargetFile));
            listItem.SubItems.Add(new ListViewItem.ListViewSubItem(listItem, item.WorkingFile));
            listView.Items.Add(listItem);

            if (select)
            {
                listItem.Selected = true;
                listItem.Focused = true;
                listItem.EnsureVisible();
            }
        }

        public static void ReloadListview(ListView listView, ImageList imageList, List<SyncItem> syncItems)
        {
            listView.Items.Clear();

            foreach (SyncItem item in syncItems)
                ListviewHelper.CreateListviewItem(listView, imageList, item);
        }

        public static List<SyncItem> GetListviewSyncItems(ListView listView)
        {
            List<SyncItem> syncItems = new List<SyncItem>();

            foreach (ListViewItem item in listView.SelectedItems)
            {
                SyncItem syncItem = item.Tag as SyncItem;
                syncItems.Add(syncItem);
            }
            return syncItems;
        }

        public static void UpdateSelectedListviewItem(ListView listView, ImageList imageList, SyncItem syncItem)
        {
            ListViewItem item = listView.SelectedItems[0];
            item.ImageKey = AddImageAssociation(imageList, syncItem);
            item.Text = syncItem.TargetTitle;
            item.SubItems[1].Text = syncItem.TargetFile;
            item.SubItems[2].Text = syncItem.WorkingFile;
        }

        private static string AddImageAssociation(ImageList imageList, SyncItem syncItem)
        {
            string ext = Path.GetExtension(syncItem.TargetFile);
            if (!imageList.Images.ContainsKey(ext))
            {
                imageList.Images.Add(ext, syncItem.GetAssociatedIcon());
            }
            return ext;
        }
    }
}
