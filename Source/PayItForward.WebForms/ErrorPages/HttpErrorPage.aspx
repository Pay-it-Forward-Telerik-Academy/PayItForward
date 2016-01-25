<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HttpErrorPage.aspx.cs" Inherits="PayItForward.WebForms.ErrorPages.HttpErrorPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
                                <p class="flat-text-logo center white-text caption-uppercase">
                                    <asp:Label ID="exMessage" runat="server" />
                                </p>
                                <p class="flat-text-logo center white-text caption-uppercase">
                                    <asp:Label ID="exTrace" runat="server" />
                                </p>

                            </div>
                            <div id="site-layout-example-right" class="col s12">
                                <div class="row center">
                                    <p class="center s12">
                                        <button onclick="goBack()" class="btn waves-effect waves-light red">Back</button>
                                        <a href="/Index" class="btn waves-effect waves-light red">Homepage</a>
                                    </p>
                                    <h1 class="text-long-shadow col s12">
                                        <asp:Label ID="exCode" runat="server" /></h1>
                                </div>
                                <div class="row center">
                                    <p class="center white-text col s12">Something has gone seriously wrong. Please try later.</p>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <asp:Panel ID="InnerErrorPanel" CssClass="content" runat="server" Visible="false">
                                <p>
                                    Inner Message:
                                    <asp:Label ID="innerMessage" runat="server" Font-Bold="true"
                                        Font-Size="Smaller" />
                                </p>
                                <hr/>
                                <p>
                                    Inner Trace:
                                    <asp:Label ID="innerTrace" runat="server" Font-Bold="true"
                                        Font-Size="X-Small" />
                                </p>
                            </asp:Panel>
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
