<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotFoundErrorPage.aspx.cs" Inherits="PayItForward.WebForms.ErrorPages.NotFoundErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="error-page">

        <div class="row">
            <div class="col s12">
                <div class="browser-window">
                    <div class="top-bar">
                        <div class="circles">
                            <div id="close-circle" class="circle"></div>
                            <div id="minimize-circle" class="circle"></div>
                            <div id="maximize-circle" class="circle"></div>
                        </div>
                    </div>
                    <div class="content">
                        <div class="row">
                            <div id="site-layout-example-top" class="col s12">
                                <p class="flat-text-logo center white-text caption-uppercase">Sorry but we couldn’t find this page :(</p>
                            </div>
                            <div id="site-layout-example-right" class="col s12">
                                <div class="row center">
                                    <p class="center s12">
                                        <button onclick="goBack()" class="btn waves-effect waves-light red">Back</button>
                                        <a href="/Index" class="btn waves-effect waves-light red">Homepage</a>
                                    </p>
                                    <h1 class="text-long-shadow col s12">
                                        <asp:Label ID="exCode" Text="404" runat="server" /></h1>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function goBack() {
            window.history.back();
        }
    </script>
</asp:Content>
