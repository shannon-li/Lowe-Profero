<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Head.ascx.cs" Inherits="SC.WebSite.Layouts.Common.UC_Head" %>
<div class="navigation-bar">
    <div class="logo">
        <a href="/">
            <sc:Image Field="Logo Picture" runat="server" Item="<%#Page.HomeItem %>" />
        </a>
    </div>
    <div class="nav-location-out"></div>
    <div class="location-dropdown uk-hidden-small uk-hidden-medium">
        <div class="location-dropdown-content">
            <div class="location"><%=Page.AreaItem.Name %></div>
            <div class="location-dropdown-sub-top-arrow"></div>
            <div class="location-dropdown-sub">
                <%
                    if (this.AreaItemList != null && this.AreaItemList.Length > 0)
                    {
                        foreach (Sitecore.Data.Items.Item item in this.AreaItemList)
                        {
                            Sitecore.Data.Items.Item[] childList = this.Get_AreaChildList(item);
                            bool isHasChild = (childList != null && childList.Length > 0) ? true : false;
                            string http = Request.Url.ToString();
                %>
                <div class="location-block">
                    <%
                            if (isHasChild)
                            {
                    %>
                    <div class="location-name"><%=item.Name %></div>
                    <div class="sub-location-block">
                        <%
                                foreach (Sitecore.Data.Items.Item childItem in childList)
                                {                                     
                        %><a href="<%=http.Replace(http.Split('.')[0],"http://"+ childItem["HttpName"]) %>" class="location-name"><%=childItem.Name %></a><%
                                }
                        %>
                    </div>
                    <%
                            }
                            else
                            {
                    %><a href="<%=http.Replace(http.Split('.')[0],"http://"+ item["HttpName"]) %>" class="location-name"><%=item.Name %></a><%
                            }
                    %>
                </div>
                <%
                        }
                    }
                %>
            </div>
        </div>
        <script type="text/javascript">
            $(function () {
                $(".sub-location-block").show();
                $(".location-dropdown-content .location").click(function () {
                    $(".location-dropdown-sub").toggle();
                });
            });
        </script>
    </div>
    <a href="/en/our-work" class="mobile-title uk-hidden-large">Work</a>
    <div class="links uk-hidden-small uk-hidden-medium">
        <asp:Literal runat="server" ID="literNAV"></asp:Literal>
        <%--<ul>
            <li>
                <a class="active" href="/en/our-work">Work</a>
            </li>
            <li>
                <a href="/en/our-services">Services</a>
            </li>
            <li>
                <a href="/en/our-people">People</a>
            </li>
            <li>
                <a href="/en/press">Press</a>
            </li>
            <li>
                <a href="/en/join-us">Join us</a>
            </li>
            <li>
                <a href="/en/contact-us">Contact us</a>
            </li>
        </ul>--%>
    </div>
    <div class="share uk-hidden-small uk-hidden-medium">
        <ul>
            <li class="tisaProBoldIta text">Follow Us:</li>
            <li><a class="twitter" href="https://twitter.com/loweprofero"></a></li>
            <li><a class="facebook" href="https://www.facebook.com/loweprofero"></a></li>
            <li><a class="youtube" href="http://www.youtube.com/user/ProferoGlobal"></a></li>
        </ul>

    </div>
    <!-- off Canvas Right Menu -->
    <div class="offcanvas-button uk-hidden-large">
        <button class="uk-button toogle-oc-menu">
            <img class="active" src="/img/menu-icon.png">
            <img src="/img/close-menu.png">
        </button>
    </div>

    <div class="offcanvas" id="right-oc-menu">
        <div class="location-city TisaSansOT-Light">
            UK<img src="/img/icons/offcanvas-location-list-icon.png">
        </div>
        <div class="block-nav-links provinces">
            <a class="TisaSansOT-Light mobileNav" data-province="global" href="http://www.loweprofero.com/en/our-work">Global
                       
                <input type="hidden" value="en" class="currentLang">
            </a>
            <a class="TisaSansOT-Light mobileNav" data-province="north america" href="http://newyork.loweprofero.com/en/our-work">North America
                       
                <input type="hidden" value="en" class="currentLang">
            </a>
            <a class="TisaSansOT-Light mobileNav" data-province="uk" href="http://london.loweprofero.com/en/our-work">UK
                       
                <input type="hidden" value="en" class="currentLang">
            </a>
            <a class="TisaSansOT-Light" data-province="apac" href="#">APAC</a>
            <div class="block-nav-links sub" data-sub-province="apac">
                <a class="TisaSansOT-Light mobileNav" href="http://singapore.profero.com/en/our-work">Singapore
                               
                    <input type="hidden" value="en" class="currentLang">
                </a>
                <a class="TisaSansOT-Light mobileNav" href="http://beijing.profero.com/en/our-work">Beijing
                               
                    <input type="hidden" value="en" class="currentLang">
                </a>
                <a class="TisaSansOT-Light mobileNav" href="http://shanghai.profero.com/en/our-work">Shanghai
                               
                    <input type="hidden" value="en" class="currentLang">
                </a>
                <a class="TisaSansOT-Light mobileNav" href="http://seoul.profero.com/en/our-work">Korea
                               
                    <input type="hidden" value="en" class="currentLang">
                </a>
                <a class="TisaSansOT-Light mobileNav" href="http://sydney.profero.com/en/our-work">Australia
                               
                    <input type="hidden" value="en" class="currentLang">
                </a>
                <a class="TisaSansOT-Light mobileNav" href="http://tokyo.profero.com/ja/our-work">Japan
                               
                    <input type="hidden" value="ja" class="currentLang">
                </a>
                <a class="TisaSansOT-Light mobileNav" href="http://hongkong.profero.com/en/our-work">Hong Kong
                               
                    <input type="hidden" value="en" class="currentLang">
                </a>
            </div>
        </div>
        <div class="block-nav-links mb-30">
            <a class="TisaSansOT-Light uk-hidden-small" href="/en/our-work">Work</a>
            <a class="TisaSansOT-Light uk-hidden-medium active" data-sub-page="work" href="#">Work</a>
            <div class="block-nav-links sub uk-hidden-medium" data-sub-page="work">
                <a class="TisaSansOT-Light active" href="/en/our-work">Case Studies</a>
                <a class="TisaSansOT-Light " href="/en/our-client">Our clients</a>
            </div>
            <a class="TisaSansOT-Light " href="/en/our-services">Services</a>
            <a class="TisaSansOT-Light uk-hidden-small" href="/en/our-people">People</a>
            <a class="TisaSansOT-Light uk-hidden-medium " data-sub-page="people" href="#">People</a>
            <div class="block-nav-links sub uk-hidden-medium" data-sub-page="people">
                <a class="TisaSansOT-Light " href="/en/our-people">Leadership team</a>
                <a class="TisaSansOT-Light " href="/en/our-people/uk">UK team</a>
                <a class="TisaSansOT-Light " href="/en/our-people/global">Global team</a>
            </div>
            <a class="TisaSansOT-Light " href="/en/press">Press</a>
            <a class="TisaSansOT-Light uk-hidden-small" href="/en/join-us">Join us</a>
            <a class="TisaSansOT-Light uk-hidden-medium " data-sub-page="join-us" href="#">Join us</a>
            <div class="block-nav-links sub uk-hidden-medium" data-sub-page="join-us">
                <a class="TisaSansOT-Light " href="/en/join-us">Our values</a>
                <a data-sub-page="avalable-jobs" class="TisaSansOT-Light ">Available Jobs</a>
                <div class="block-nav-links sub uk-hidden-medium" data-sub-page="avalable-jobs">
                    <a class="TisaSansOT-Light " href="/en/join-us/management-accountant">Management Accountant</a>
                    <a class="TisaSansOT-Light " href="/en/join-us/account-executive">Account Executive</a>
                    <a class="TisaSansOT-Light " href="/en/join-us/senior-project-manager-(1)">Senior Project Manager (1)</a>
                    <a class="TisaSansOT-Light " href="/en/join-us/project-manager-(1)">Project Manager (1)</a>
                    <a class="TisaSansOT-Light " href="/en/join-us/senior-producerproject-manager">Senior Producer/Project Manager</a>
                    <a class="TisaSansOT-Light " href="/en/join-us/search-account-manager-(1)">Search Account Manager (1)</a>
                    <a class="TisaSansOT-Light " href="/en/join-us/community-manager">Community Manager</a>
                    <a class="TisaSansOT-Light " href="/en/join-us/junior-designer">Junior Designer</a>
                    <a class="TisaSansOT-Light " href="/en/join-us/senior-account-executive">Senior Account Executive</a>
                </div>
                <a class="TisaSansOT-Light " href="/en/join-us/apply-for-position">Apply for position</a>
            </div>
            <a class="TisaSansOT-Light " href="/en/contact-us">Contact us</a>
        </div>
        <div class="separator"></div>
        <div class="follow-us">
            <div class="title TisaSansOT-Light">Follow Us:</div>
            <ul>
                <li>
                    <a href="https://twitter.com/loweprofero">
                        <img src="/img/icons/twitter-icon-big.png">
                    </a>
                    <a href="https://www.facebook.com/loweprofero">
                        <img src="/img/icons/facebook-icon-big.png">
                    </a>
                    <a href="http://www.youtube.com/user/ProferoGlobal">
                        <img src="/img/icons/youtube-icon-big.png">
                    </a>
                </li>
            </ul>
        </div>
        <div class="separator"></div>
        <div class="bottom-links">
            <a class="TisaSansOT-Light" href="/en/footer/accessibility">Accessibility</a>
            <a class="TisaSansOT-Light" href="/en/footer/privacy-cookie-policy">Privacy &amp; Cookie Policy</a>
            <a class="TisaSansOT-Light" href="/en/footer/terms-of-use">Terms of use</a>
            <a class="TisaSansOT-Light" href="/en/footer/sitemap">Site map</a>
            <a class="TisaSansOT-Light" href="#">&copy; Profero Limited 2013</a>
        </div>
    </div>
</div>
