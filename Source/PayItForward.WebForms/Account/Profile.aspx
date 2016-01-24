<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PayItForward.WebForms.Account.Profile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col s12 m4 l4">
            <h4 class="header">Profile Card</h4>
            <div id="profile-card" class="card">
                <div class="card-image waves-effect waves-block waves-light">
                    <img class="activator" src="../Resources/Images/user-bg.jpg" alt="user bg">
                </div>
                <div class="card-content">
                    <img src="<%= CurrentUser.AvatarUrl %>" alt="" class="circle responsive-img activator card-profile-image">
                    <a runat="server" href="~/Account/ManagePassword" class="btn-floating activator btn-move-up waves-effect waves-light darken-2 right">
                        <i class="mdi-editor-mode-edit"></i>
                    </a>

                    <span class="card-title activator grey-text text-darken-4"><%= CurrentUser.UserName %></span>
                    <p><i class="mdi-action-perm-identity"></i><%=CurrentUser.Email %></p>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
