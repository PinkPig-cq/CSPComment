using PagedList.Core.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    /// <summary>
    /// 封装的PagedList.MVC.Core样式
    /// </summary>
    public static class PageListOptions
    {
        //获取配置
        public static PagedListRenderOptions GetPagedListRenderOptions
        {
            get{
                return new PagedListRenderOptions()
                {
                    DisplayEllipsesWhenNotShowingAllPageNumbers = true,
                    LinkToPreviousPageFormat = "上一页",
                    LinkToNextPageFormat = "下一页",
                    DisplayLinkToFirstPage = PagedListDisplayMode.IfNeeded,
                    DisplayLinkToLastPage = PagedListDisplayMode.IfNeeded,
                    DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
                    DisplayLinkToNextPage = PagedListDisplayMode.Always,
                    DisplayLinkToIndividualPages = true,
                    ClassToApplyToFirstListItemInPager = "previous",
                    ClassToApplyToLastListItemInPager = "next",
                };
            }
        }
    }
}
