<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="SC.WebSite.Layouts.Work.List" %>
<div class="offcanvas-menu-overlay"></div>
<div class="main-content">
    <div class="global-work-bg"></div>
    <div class="global-work">
        <div class="work-content">
            <h1 class="kit-main-title"><%=Page.AreaItem.Name %> Work</h1>
            <div class="custom-grid">

                <asp:Repeater ID="Repeater_WorkList" runat="server">
                    <ItemTemplate>
                        <div class="custom-width-xlarge-1-5 custom-width-xlarge-1-4 custom-width-large-1-3 custom-width-medium-1-2 custom-width-small-1-1">
                            <a class="work-link" href="<%#Sitecore.Links.LinkManager.GetItemUrl((Sitecore.Data.Items.Item)Container.DataItem).ToLower() %>">
                                <div class="work-elem">
                                    <sc:Image ID="Photo" Field="Photo" runat="server" Width="185" Height="107" Item="<%# Container.DataItem %>" />
                                    <div class="work-elem-description-block">
                                        <div class="work-elem-title tisaProBoldIta">
                                            <p>
                                                <sc:Text runat="server" ID="Title" Field="Title" Item="<%# Container.DataItem %>" />
                                            </p>
                                        </div>
                                        <div class="work-elem-sub TisaSansOT">
                                            <sc:Text runat="server" ID="Company" Field="Company" Item="<%# Container.DataItem %>" />
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
        <div class="uk-hidden-small brand-content is_not_touch" style="top: 70px;">
            <h2 class="kit-title-2">Our Clients</h2>
            <asp:Repeater ID="Repeater_ClientList" runat="server">
                <ItemTemplate>
                    <div class="brand-elem">
                        <sc:Image Field="ClientLogo" runat="server" Item="<%# Container.DataItem %>" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</div>
