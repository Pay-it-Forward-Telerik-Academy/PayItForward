<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Details.aspx.cs" Inherits="PayItForward.WebForms.Story.Details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row center">
        <h3 id="storyTitle" runat="server" class="header grey-text"></h3>
    </div>
    <div class="card-panel z-depth-4">
        <div class="row center">
            <div class="col s6">
                <div class="card card-panel z-depth-4" style="overflow: hidden;">
                    <div class="card-image">
                        <asp:Image ID="imageStory" runat="server" Width="100%" />
                    </div>
                    <div class="card-content">
                        <div class="col s6">
                            <span id="likes" runat="server"></span>
                            <asp:LinkButton ID="likeButton"
                                runat="server">
                                    <span><i class="small material-icons">thumb_up</i></span>
                            </asp:LinkButton>
                        </div>
                        <div class="col s6"><span class="activator blue-text text-darken-2"><i class="material-icons dp48">chat_bubble_outline</i></span></div>
                    </div>
                    <div class="card-reveal" style="display: none; transform: translateY(0px);">
                        <span class="card-title grey-text text-darken-4">Comments<i class="material-icons right">close</i></span>
                        <p class="triangle-right">This only needs one HTML element.</p>
                        <asp:Repeater ID="CommentsRepeater" runat="server">
                            <ItemTemplate>
                        <p class="triangle-right"><%#: Eval("Context") %></p>
                                </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="col s6 ">
                <div class="card  light-blue">
                    <div class="card-content white-text">
                        <span class="card-title">Description</span>
                        <p id="storyDescription" runat="server"></p>
                        <div class="center">
                            <span id="collectedAmount" runat="server"></span>
                            <span>of </span>
                            <span id="goalAmount" runat="server"></span>
                        </div>
                        <div class="progress">
                            <div class="determinate" id="progressBar" runat="server"></div>
                        </div>
                    </div>
                    <div class="card-action">
                        <a href="#" class="lime-text text-accent-1">Donate</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
