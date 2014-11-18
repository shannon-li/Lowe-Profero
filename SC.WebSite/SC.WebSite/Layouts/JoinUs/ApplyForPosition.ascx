<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApplyForPosition.ascx.cs" Inherits="SC.WebSite.Layouts.JoinUs.ApplyForPosition" %>


<!DOCTYPE html>
<html>
<head>
    <title>Lowe Profero UK-Apply For Position</title>
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />



    <link href="/css/uikit_new.css" rel="stylesheet" />
    <link href="/css/customFont.css?v=2" rel="stylesheet" />
    <link href="/css/main.css?v=3" rel="stylesheet" />
    <link href="/css/main1.css?v=92" rel="stylesheet" />

    <!--[if IE 9]>
    <link rel="stylesheet" href="/css/main_ie9.css?v=2"><![endif]-->
    <!--[if IE 8]>
    <link rel="stylesheet" href="/css/main_ie8.css"><![endif]-->

    <!--[if lt IE 9]> 
    <script src="/static/js/json2js.js"></script>
    <script src="/static/js/respond.js"></script>
    <script src="/static/js/html5shiv.js"></script><![endif]-->
    <!--[if lt IE 8]>
    <script src="/static/js/ie8.js"></script>
    <![endif]-->
    <!-- jQuery 1.9.1-->
    <script src="/static/js/fastclick.js"></script>
    <script src="/static/js/jquery.min.js"></script>

    <script src="/static/js/uikit.js"></script>
    <script src="/static/js/jquery.event.move.js"></script>
    <script src="/static/js/jquery.event.swipe.js"></script>
    <script src="/static/js/offcanvas-menu.js"></script>
    <script src="/static/js/touchdetection.js"></script>
    <script src="/static/js/jquery-migrate-1.2.1.js"></script>
    <link href="/css/main_attach.css?v=1" rel="stylesheet" />
 <%--   <script>
        var office = 'UK';
        var lang = 'en';
        var curUrl = '/en/join-us/apply-for-position';
    </script>--%>


<%--    <script src="/static/js/jquery-migrate-1.2.1.js"></script>--%>


<%--    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-907163-3']);
        _gaq.push(['_trackPageview']);
        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>--%>
</head>
<body class="is_not_touch">
    <div class="profero">
        <div class="offcanvas-menu-overlay"></div>
        <div class="main-content">


            <div class="join-us">
                <div class="uk-grid">
                    <div class="uk-width-large-1-10 uk-hidden-small">&nbsp;</div>
                    <div class="uk-width-large-3-10 uk-width-medium-1-3 left-menu uk-hidden-small">
                        <div class="kit-left-menu-elem highlight uk-hidden-small">
                            <a class="link-title" href="/en/join-us/values">Our Values</a>
                        </div>
                        <div auto-select class="kit-left-menu-elem category show uk-hidden-small">
                            <div class="menu-title drop drop-small">Available Jobs</div>
                            <div class="link-grid">

                                <a href="/en/join-us/management-accountant" class="kit-font-light-grey">Management Accountant</a>
                                <a href="/en/join-us/account-executive" class="kit-font-light-grey">Account Executive</a>
                                <a href="/en/join-us/senior-project-manager-(1)" class="kit-font-light-grey">Senior Project Manager</a>
                                <a href="/en/join-us/project-manager-(1)" class="kit-font-light-grey">Project Manager</a>
                                <a href="/en/join-us/senior-producerproject-manager" class="kit-font-light-grey">Senior Producer/Project Manager</a>
                                <a href="/en/join-us/search-account-manager-(1)" class="kit-font-light-grey">Search Account Manager</a>
                                <a href="/en/join-us/community-manager" class="kit-font-light-grey">Community Manager</a>
                                <a href="/en/join-us/junior-designer" class="kit-font-light-grey">Junior Designer</a>
                                <a href="/en/join-us/senior-account-executive" class="kit-font-light-grey">Senior Account Executive</a>
                            </div>
                        </div>
                        <div class="kit-left-menu-elem category">
                            <a href="/en/join-us/apply-for-position" class="link-title active">Apply for position</a>
                        </div>

                    </div>
                    <div class="uk-width-custom uk-hidden-medium uk-hidden-small" style="width: 5%">&nbsp;</div>
                    <div class="uk-width-large-4-10 uk-width-medium-2-3 uk-width-small-1-1 page-content">


                        <h1 class="kit-main-title">Apply for position</h1>
                        <div class="page-description">
                            We&#39;re always on the lookout for good people. Even if we&#39;re not advertising for your role right now, we&#39;d still like to hear from you.
                        </div>
                        <form class="kit-form" method="post" action="/api/UK/apply-job" enctype="multipart/form-data">
                            <input type="hidden" name="contactTitle" value="Available positions " />
                            <input type="hidden" name="contactName" value="Tina Brazil" />
                            <input type="hidden" name="contactEmail" value="IWantToWork@loweprofero.com" />
                            <input type="hidden" name="emailSubject" value="Loweprofero.com - CV Submissions" />
                            <input type="hidden" name="returnUrl" value="/en/join-us/apply-for-position" />
                            <label>
                                What is your name?
            <div class="error name">Sorry but this field is required</div>

                            </label>
                            <input type="text" name="name" id="txt_name" runat="server" />
                            <label>
                                What role were you after?
            <div class="error role">Sorry but this field is required</div>

                            </label>
                            <input type="text" id="txt_role" runat="server" name="role" value="" />
                            <label>
                                What is your email?
            <div class="error email">Sorry but a valid email is required</div>

                            </label>
                            <input type="text" id="txt_email" runat="server" name="email" />
                            <label>
                                Do you have a resume or portfolio to attach?
            <div class="error"></div>
                            </label>
                            <div class="file_upload_block">
                                <input type="file" name="photo" id="photo" style="width: 100%; height: 30px; line-height: 30px; opacity: 0; float: left; display: none;" />
                                <input type="text" class="ie8_hide" name="file_name" placeholder="Only picture, .doc file, .pdf file and .zip file are supported" value="Only picture, .doc file, .pdf file and .zip file are supported" />
                                <button class="select-file ie8_hide">Select file</button>
                            </div>
                            <label>
                                Any other messages for us?
            <div class="error message">Sorry but the message is required</div>
                            </label>
                            <textarea name="message" id="txt_message" runat="server"></textarea>
                            <div class="reminder">
                                Don&#39;t forget to include a live url if you have one
                            </div>
                            <div class="form-bottom">
                                <button class="send">Submit Application</button>
                                <script type="text/javascript">
                                    /*$(function () {
                                        $(".send").click(function (e) {
                                            e.preventDefault(); $("form").submit(); return false;
                                        });
                    
                                    });*/
                                </script>
                            </div>
                        </form>


                    </div>
                </div>
            </div>


        </div>
    </div>




    <script type="text/javascript">
        // left menu slide animation
        $(function () {
            $('.left-menu .kit-left-menu-elem.master-category .menu-title').click(function () {
                $(this).parent().toggleClass('selected');
                return $('.left-menu .kit-left-menu-elem.category').slideToggle();
            });
            $('.left-menu .kit-left-menu-elem.category .menu-title').click(function () {
                $(this).parent().toggleClass('selected');
                return $(this).parent().find('.link-grid').slideToggle();
            });
        });
    </script>

    <script type="text/javascript">
        (function () {
            /*JobItem*/
            var onchange_file;
            var time_file = null;

            if ($.browser.msie && $.browser.version == "8.0") {
                $('.ie8_hide').hide();
                $('#photo').show().css('float', 'none').css('position', 'relative');
            }

            $(".select-file").click(function (e) {
                e.preventDefault();
                $("#photo").click();

            });

            $('label').click(function () {
                return $(this).next().focus();
            });

            onchange_file = function () {
                if ($('input[name="photo"]').val() == "") {
                    $('input[name="file_name"]').val("Only picture, .doc file, .pdf file and .zip file are supported");
                } else {
                    $('input[name="file_name"]').val($('input[name="photo"]').val());
                }
            };


            $('input[name="photo"]').change(function () {
                return onchange_file();
            });


            $('input[name="name"]').blur(function () {
                if ($(this).val() === "") {
                    $(this).addClass('error');
                    return $('.error.name').addClass('show');
                } else {
                    $(this).removeClass('error');
                    return $('.error.name').removeClass('show');
                }
            });

            $('input[name="role"]').blur(function () {
                if ($(this).val() === "") {
                    $(this).addClass('error');
                    return $('.error.role').addClass('show');
                } else {
                    $(this).removeClass('error');
                    return $('.error.role').removeClass('show');
                }
            });

            $('input[name="email"]').blur(function () {
                var emailVar = $(this).val();
                var email = /^[\w]+[\w.\-_]{1,}@(\w)+((\.\w+)+)$/;
                if (!email.test(emailVar)) {
                    $(this).addClass('error');
                    return $('.error.email').addClass('show');
                } else {
                    $(this).removeClass('error');
                    return $('.error.email').removeClass('show');
                }
            });

            $('textarea').blur(function () {
                if ($(this).val() === "") {
                    $(this).addClass('error');
                    return $('.error.message').addClass('show');
                } else {
                    $(this).removeClass('error');
                    return $('.error.message').removeClass('show');
                }
            });

            $('button.send').click(function (e) {
                /*if ($.browser.msie && $.browser.version == "8.0") {
                    l = $('label .error.show').get().length;
                    if (l === 0) {
                        return $('form.kit-form').submit();
                    } else { return false; }
                }*/
                var l, _i, _len, _ref;
                e.preventDefault();
                e.stopPropagation();
                _ref = $('input[name="name"],input[name="role"],input[name="email"],textarea').get();
                for (_i = 0, _len = _ref.length; _i < _len; _i++) {
                    e = _ref[_i];
                    if ($(e).val().length === 0) {
                        $(e).blur();
                    }
                }
                l = $('label .error.show').get().length;
                if (l === 0) {
                    return $('form.kit-form').submit();
                } else { return false; }
            });
        }).call(this);
    </script>


    <script type="text/javascript">
        $(function () {
            if ($.browser.msie && $.browser.version == "10.0") {
                $('.profero .location-dropdown .location-dropdown-content .location').css("line-height", "35px");
                $('.profero .join-us .uk-grid .kit-left-menu-elem .menu-title').css("line-height", "45px")
            }
        })
    </script>
</body>
</html>


