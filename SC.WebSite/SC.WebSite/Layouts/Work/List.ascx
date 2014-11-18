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
            <div class="brand-elem">
                <img src="/media/227622/all-saints.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/289846/asos_logo.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/270307/avon.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/222469/baileys.png">
            </div>
            <div class="brand-elem">
                <img src="/media/168422/barclays.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168427/bayer.png">
            </div>
            <div class="brand-elem">
                <img src="/media/286530/benefit.png">
            </div>
            <div class="brand-elem">
                <img src="/media/168442/catalent.png">
            </div>
            <div class="brand-elem">
                <img src="/media/168447/change4life.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/289368/cj.png">
            </div>
            <div class="brand-elem">
                <img src="/media/227727/comfort.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168457/diageo.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/209254/ea_logo.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168477/fnco.png">
            </div>
            <div class="brand-elem">
                <img src="/media/168472/fedex.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/227637/frank.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/270312/gm.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/286555/google.png">
            </div>
            <div class="brand-elem">
                <img src="/media/168487/gsk.png">
            </div>
            <div class="brand-elem">
                <img src="/media/293857/guinness.png">
            </div>
            <div class="brand-elem">
                <img src="/media/168502/hsbc.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168702/jeremiah_weed.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/227732/logo_0019_jw.png">
            </div>
            <div class="brand-elem">
                <img src="/media/222464/johnson_johnson.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168707/llumar.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/286560/lufthansa.png">
            </div>
            <div class="brand-elem">
                <img src="/media/294177/m_s.png">
            </div>
            <div class="brand-elem">
                <img src="/media/272661/macys.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/170676/malts.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168577/mohegan.png">
            </div>
            <div class="brand-elem">
                <img src="/media/168582/ms_australia.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/294330/mtma.png">
            </div>
            <div class="brand-elem">
                <img src="/media/168587/thenyctimes.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/309079/new life media.png">
            </div>
            <div class="brand-elem">
                <img src="/media/209508/nrma.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/270317/pepsico.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168622/pizza_hut.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168632/roadshow_entertainment.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/340616/sjf.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168642/skype.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168647/smirnoff.png">
            </div>
            <div class="brand-elem">
                <img src="/media/168652/spontex.png">
            </div>
            <div class="brand-elem">
                <img src="/media/168657/suzannegrae.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168717/talisker.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168712/singleton.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/168662/tresemme.png">
            </div>
            <div class="brand-elem">
                <img src="/media/277309/unilever.png">
            </div>
            <div class="brand-elem">
                <img src="/media/227330/vonage.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/227632/westernunion.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/271195/woolmark.jpg">
            </div>
            <div class="brand-elem">
                <img src="/media/286520/yahoo.png">
            </div>
            <div class="brand-elem">
                <img src="/media/286590/youtube.png">
            </div>
        </div>
    </div>

</div>
