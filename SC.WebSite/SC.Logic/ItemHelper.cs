using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP.Logic
{
    /// <summary>
    /// Sitecore ItemHelper
    /// Company: Lowe Profero
    /// Version: 1.0
    /// </summary>
    public class ItemHelper
    {
        /// <summary>
        /// 获取指定的父级Item
        /// </summary>
        /// <param name="currentItem">当前Item</param>
        /// <param name="itemName">指定ItemName</param>
        /// <returns>Sitecore.Data.Items.Item</returns>
        public static Sitecore.Data.Items.Item GetAssignParent(Sitecore.Data.Items.Item currentItem, string itemName)
        {
            if (currentItem == null || currentItem.TemplateName.Equals(itemName, StringComparison.InvariantCultureIgnoreCase))
            {
                return currentItem;
            }
            return currentItem.Parent != null ?
            GetAssignParent(currentItem.Parent, itemName) : null;
        }

        /// <summary>
        /// 递归父级Item.ID是否与当前ID相等
        /// </summary>
        /// <param name="currentItem"></param>
        /// <param name="idList"></param>
        /// <returns>bool</returns>
        public static bool ItemParentIsEqualsId(Sitecore.Data.Items.Item currentItem, string id)
        {
            if (currentItem == null)
            {
                return false;
            }
            else if (currentItem.ID.ToString() == id)
            {
                return true;
            }
            else
            {
                return ItemParentIsEqualsId(currentItem.Parent, id);
            }
        }
    }
}
