<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="SC.WebSite.Layouts.Work.Detail" %>
<div class="main-content">

    <div class="work">
        <!-- Nav -->
        <div class="work-header" style="top: 71px;">
            <h1><sc:Text Field="Title" runat="server" /></h1>
            <div class="h2-content-decorator">
                <h2><h1><sc:Text Field="Company" runat="server" /></h1></h2>
            </div>
            <div class="top-links uk-hidden-small">
                <a class="active" go-to="casestudy" href="#">Overview</a>
                <a go-to="challenge" href="#">The challenge

</a>
                <a go-to="solution" href="#">The Idea

</a>
                <a go-to="howwedid" href="#">How we did it</a>
                <a go-to="gallery" href="#">Gallery</a>
            </div>
        </div>
        <!-- End Nav -->
        <!-- Overview -->
        <div class="work-main-picture" position-location="casestudy" style="padding-top: 174px;">
            <div class="work-main-picture-white-bg"></div>
            <div class="main-illustration">
                <img alt="Baileys.com" src="/media/164455/baileys_rankin_european.jpg">
            </div>
        </div>
        <!-- End Overview -->
        <div class="work-content">
            <!-- Challenge -->
            <h3 position-location="challenge">The challenge

</h3>

            <p>
                Create a content management system that could be used by Diageo
employees and local agencies all around the world.
            </p>
            <!-- End Challenge -->
            <!-- Idea -->
            <h3 position-location="solution">The Idea

</h3>

            <p>
                A universal, personalised CMS with advanced features and elegant
front end
            </p>
            <!-- End Idea -->
            <!-- How we did it -->
            <h3 position-location="howwedid">How we did it</h3>

            <p>
                A site was created that reflected the brand feel associated with
Baileys
            </p>

            <p>
                Adhering to strict internal guidelines and policies set by
Diageo we delivered a powerful CMS that had enough flexibility to
meet local markets' requirements, through personalized templates,
but that maintained the consistency of Baileys.com among an
international audience - essential in today's increasingly
globalised culture.
            </p>
            <!-- End How we did it -->
            <br>
        </div>
        <!-- Gallery -->
        <div class="work-slider">
            <h3 position-location="gallery">Gallery</h3>
            <div class="slider-border swipe">
                <div class="slider-left-border"></div>
                <div class="slider-right-border"></div>
                <table class="swipe-wrap" style="width: 4568px; margin-left: -1713px;">
                    <tbody>
                        <tr>
                            <td style="width: 953.6px; padding: 20px;">
                                <img id="id-4627" alt="img1" src="/media/164392/baileys_hero_range.jpg" style="width: 873.6px;"></td>
                            <td style="width: 953.6px; padding: 20px;">
                                <img id="id-4628" alt="img2" src="/media/164395/screen shot 2012-06-13 at 14.34.31.png" style="width: 873.6px;"></td>
                            <td style="width: 953.6px; padding: 20px;">
                                <img id="id-4629" alt="img3" src="/media/164398/screen shot 2012-06-13 at 14.22.58.png" style="width: 873.6px;"></td>
                            <td style="width: 953.6px; padding: 20px;">
                                <img id="id-4630" alt="img4" src="/media/164401/screen shot 2012-06-13 at 14.31.41.png" style="width: 873.6px;"></td>
                            <td style="width: 953.6px; padding: 20px;">
                                <img id="id-4631" alt="img5" src="/media/164404/screen shot 2012-06-13 at 14.34.04.png" style="width: 873.6px;"></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="slider-mobile-controls uk-hidden-large">
                <div class="nav-prev"></div>
                <div class="dots">
                    <div class="dot active"></div>
                    <div class="dot"></div>
                    <div class="dot"></div>
                    <div class="dot"></div>
                    <div class="dot"></div>
                </div>
                <div class="nav-next"></div>
            </div>
        </div>
        <div class="slider-zoom" style="">
            <div style="display: none" class="slider-zoom-bg"></div>
            <div class="close-slide-display">×</div>
            <div class="bottom-nav-block">
                <div class="content-zoom">
                    <div class="img-display">
                        <img src="" style="height: 1273.8px;">
                    </div>
                    <div class="pic_list uk-hidden-small">
                        <img alt="img1" src="/media/164392/baileys_hero_range.jpg">
                        <img alt="img2" src="/media/164395/screen shot 2012-06-13 at 14.34.31.png">
                        <img alt="img3" src="/media/164398/screen shot 2012-06-13 at 14.22.58.png">
                        <img alt="img4" src="/media/164401/screen shot 2012-06-13 at 14.31.41.png">
                        <img alt="img5" src="/media/164404/screen shot 2012-06-13 at 14.34.04.png">
                    </div>
                </div>
            </div>
        </div>
        <!-- End Gallery -->
        <div class="work-content">
            <!-- Results -->
            <!-- End Results -->
            <!-- Awards -->
            <!-- End awards -->
        </div>
        <!-- More case study -->
        <div class="more-cases">
            <h2>More case studies</h2>
            <div class="more-cases-content">
                <div class="uk-grid">
                    <div class="uk-width-large-1-3">
                        <div class="case-elem">
                            <a href="/works/en/shanghai/lufthansa-rr-migration-campaign">
                                <img alt="Migrate with A380" src="/media/311682/lh_344x190.jpg">
                                <div class="case-text">
                                    <div class="case-title">Migrate with A380</div>
                                    <div class="case-description">
                                        Lufthansa                                           
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="uk-width-large-1-3">
                        <div class="case-elem">
                            <a href="/works/en/singapore/dfscom-case-study">
                                <img alt="DFS.com Case Study" src="/media/349482/hero_344x190.jpg">
                                <div class="case-text">
                                    <div class="case-title">DFS.com Case Study</div>
                                    <div class="case-description">
                                        DFS                                           
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="uk-width-large-1-3">
                        <div class="case-elem">
                            <a href="/works/en/uk/upc-cablecom">
                                <img alt="How do you want to feel?" src="/media/277525/upc_thumb.jpg">
                                <div class="case-text">
                                    <div class="case-title">How do you want to feel?</div>
                                    <div class="case-description">
                                        UPC cablecom                                           
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <a class="button-our-work" href="/en/our-work">See all our case studies</a>
            </div>
        </div>
        <!-- End More case study -->
    </div>

</div>
