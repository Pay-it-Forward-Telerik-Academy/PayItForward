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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" class="panel"
                            UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="col s3">
                                    <asp:LinkButton ID="likeButton" OnClick="OnAddLike"
                                        runat="server">
                                        <span class="btn-floating btn-move-up waves-effect waves-light darken-2 right">
                                            <i class="mdi-action-favorite" style="position: relative"></i><small id="likes" runat="server" style="position: absolute; left: 11px; top: 1px; color: #26A69A;">10</small>
                                        </span>
                                    </asp:LinkButton>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="col s6">
                            <%--<span class="btn-floating btn-move-up waves-effect waves-light darken-2 right">
                                <small id="Small1" runat="server" style="position: absolute; left: 11px; top: 1px; color: white;">View</small>
                            </span>--%>
                            <span class="activator white-text text-darken-2 btn-floating waves-effect waves-light right">View</span>
                        </div>
                    </div>
                    <div class="card-reveal" style="display: none; overflow: hidden; transform: translateY(0px);">
                        <span class="card-title grey-text text-darken-4">Comments<i class="material-icons right">close</i></span>
                        <asp:UpdatePanel ID="UpdatePanelFavoriteDrink" runat="server" style="max-height: 60%; overflow-y: scroll; overflow-x: hidden;" class="panel"
                            UpdateMode="Conditional">
                            <ContentTemplate>
                                <ul>
                                    <asp:Repeater ID="CommentsRepeater" runat="server">
                                        <ItemTemplate>
                                            <li class="">
                                                <div class="dialogbox">
                                                    <div class="body">
                                                        <span class="tip tip-up"></span>
                                                        <div class="message">
                                                            <span><%#: Eval("Context") %></span>
                                                            <span><%#Eval("CreatedOn") %></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%-- <div class="collapsible-header"><i class="material-icons">library_books</i><%#: Eval("User.Email") %></div>
                                                <div class="collapsible-body" style="display: none;">
                                                    <p><%#: Eval("Context") %> </p>
                                                </div>--%>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                                <div class="row">
                                    <div class="col s12 fixed-bottom">
                                        <div class="row">
                                            <div class="input-field col s12">
                                                <input runat="server" id="comment" type="text">
                                                <label for="email" data-error="wrong" data-success="right">Comment</label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <asp:LinkButton CssClass="btn btn-default" OnClick="OnAddComment" ID="addComment" runat="server">Add Comment</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="col s6 ">
                <div class="card">
                    <div class="card-content grey-text">
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
                        <span class="teal-text text-accent-1">Expiration Date:</span><div runat="server" id="expiratonDate"></div>
                    </div>
                    <div class="card-action">
                        <a href="/Story/Donate?id=<%=Request.QueryString["id"]%>" class="teal-text text-accent-1">Donate</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
