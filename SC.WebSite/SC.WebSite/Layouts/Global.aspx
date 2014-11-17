<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Global.aspx.cs" Inherits="SC.WebSite.Layouts.Global" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Content/Css/global.css" rel="stylesheet" />
    <sc:Placeholder ID="UC_Css" Key="UC_Css" runat="server" />
    <sc:Placeholder ID="UC_JS" Key="UC_JS" runat="server" />
</head>
<body>
    <div class="profero">
        <sc:Placeholder ID="UC_Head" Key="UC_Head" runat="server" />
        <sc:Placeholder ID="UC_Body" Key="UC_Body" runat="server" />
        <sc:Placeholder ID="UC_Foot" Key="UC_Foot" runat="server" />
    </div>
    <form id="hidden_form" runat="server"></form>
</body>
</html>
