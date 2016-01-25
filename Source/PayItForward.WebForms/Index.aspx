<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" MasterPageFile="~/Site.Master" Inherits="PayItForward.WebForms.Home.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="SortType" runat="server" Value="" />

    <div class="row">
        <div class="col s3">
            <asp:ListView ID="CategoriesMenu" runat="server">
                <EmptyDataTemplate>No Menu Items.</EmptyDataTemplate>
                <ItemSeparatorTemplate></ItemSeparatorTemplate>
                <ItemTemplate>
                    <li class="card-panel hoverable center  teal">
                        <a class="white-text " style="display: block; width: 100%; height: 100%;" href='<%# VirtualPathUtility.ToAbsolute("~/Index?CategoryId=" + 
                                Eval("Id")) %>'><%# Eval("Name") %></a>
                    </li>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                    <div>
                    </div>
                </LayoutTemplate>
            </asp:ListView>
        </div>
        <div class="col s9">
            <asp:ListView ID="lvStories" runat="server" GroupPlaceholderID="groupPlaceHolder1"
                ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging">
                <LayoutTemplate>
                    <div class="row">
                        <div class="col s12">
                            <%--<asp:Button ID="Button1" CssClass="waves-effect waves-light  btn" runat="server" Text="Latest"><i class="mdi-action-3d-rotation left"></i></asp:Button>--%>
                            <div class="col s3">
                                <asp:LinkButton runat="server" OnClick="OnLatestStoryButtonClicked" CssClass="waves-effect waves-light  btn">
                <i class="mdi-action-autorenew left"></i>
                Latest Stories
                                </asp:LinkButton>
                            </div>
                            <div class="col s3">
                                <%--<button runat="server" OnClick="OnLatestStoryButtonClicked" class="waves-effect waves-light  btn"><i class="mdi-action-autorenew left"></i>Latest</button>--%>
                                <asp:LinkButton runat="server" OnClick="OnMostPopularStoryButtonClicked" CssClass="waves-effect waves-light  btn">
                <i class="mdi-action-favorite-outline left"></i>
                Most Popular Stories
                                </asp:LinkButton>
                            </div>
                            <div class="col s3">
                                <asp:LinkButton runat="server" OnClick="OnAlmostThereStoryButtonClicked" CssClass="waves-effect waves-light  btn">
                <i class="mdi-editor-insert-emoticon left"></i>
                Almost There
                                </asp:LinkButton>
                            </div>
                            <div class="col s3">
                                <asp:LinkButton runat="server" OnClick="OnCriticalStoryButtonClicked" CssClass="waves-effect waves-light  btn">
                <i class="mdi-content-add-circle-outline left"></i>
                Critical Stories
                                </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    <div class="row">
                        <div class="col s12">
                            <div class="card-panel z-depth-4">
                                <div class="form-horizontal">
                                    <%--<h4><%: Title %></h4>--%>
                                    <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false">
                                        <p class="text-danger">
                                            <asp:Literal runat="server" ID="FailureText" />
                                        </p>
                                    </asp:PlaceHolder>
                                    <div class="row">
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                    </div>
                                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvStories" PageSize="6">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                                ShowNextPageButton="false" />
                                            <asp:NumericPagerField ButtonType="Link" />
                                            <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </div>
                        </div>
                    </div>
                </LayoutTemplate>
                <GroupTemplate>
                    <div class="col s4">
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                    </div>
                </GroupTemplate>
                <ItemTemplate>

                    <%--<%#  (Container.ItemIndex == 0 || (Container.ItemIndex +1 ) % 3 == 1) ? @"<div class='row'>":"" %>--%>
                    <div id="profile-card" class="card hoverable">
                        <div class="card-image waves-effect waves-block waves-light">
                            <img style="height: 170px;" class="activator" src="<%#:Eval("ImageUrl")%>" alt="user bg">
                        </div>
                        <div class="card-content">
                            <img src="<%#: Eval("User.AvatarUrl") %>"" alt="" class="circle responsive-img activator card-profile-image-index">
                            <span class="btn-floating activator btn-move-up waves-effect waves-light darken-2 right">
                                <i class="mdi-action-favorite" style="position: relative"></i><small style="position: absolute; left: 13px; top: 1px; color: #26A69A;"><%#: Eval("Likes") %></small>
                            </span>
                            <div>
                                <span style="font-size: 17px; font-weight: normal; line-height: 0" class="card-title activator grey-text text-darken-4"><%#: Eval("Title")%></span>
                            </div>
                            <p><i class="mdi-action-perm-identity"></i><%#: Eval("User.Username")%></p>
                            <div class="center">
                                <span id="collectedAmount">$<%#: Eval("CollectedAmount") %></span>
                                <span>of </span>
                                <span id="goalAmount">$<%#: Eval("GoalAmount") %></span>
                            </div>
                            <div class="progress">
                                <div class="determinate" id="progressBar"  <%#: "style= width:" +  (((double)Eval("CollectedAmount")/(double)Eval("GoalAmount"))*100) + "%;"%>"></div>
                            </div>


                        </div>
                        <div class="card-reveal">
                            <div class="col s10">
                                <a href="/Story/Details?id=<%#: Eval("Id") %>"><span class="card-title grey-text text-darken-4"><%#: Eval("Title") %> </span></a>
                            </div>
                            <div class="col s2">
                                <span class="card-title grey-text text-darken-4"><i class="mdi-navigation-close right"></i></span>
                            </div>
                            <p class="crop"><%#:Eval("Description") %></p>
                            <p><i class="mdi-action-perm-identity"></i><%#:Eval("User.Username") %></p>
                            <p><i class="mdi-communication-email"></i><%#: Eval("User.Email") %></p>
                            <div class="center">
                                <span>$<%#: Eval("CollectedAmount") %></span>
                                <span>of </span>
                                <span>$<%#: Eval("GoalAmount") %></span>
                            </div>
                            <div class="progress">
                                <div class="determinate" <%#: "style= width:" +  (((double)Eval("CollectedAmount")/(double)Eval("GoalAmount"))*100) + "%;"%>"></div>
                            </div>
                            <p>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
