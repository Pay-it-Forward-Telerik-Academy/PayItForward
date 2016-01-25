<%@ Page Title="" Language="C#"
    MasterPageFile="~/Administration/Administration.master"
    AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs"
    Inherits="PayItForward.WebForms.Administration.AdminPanel" %>

<asp:Content ID="ContentAdminPanel" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="card-panel hoverable">
        <div class="row">
            <div class="col offset-s1 s3">
                <div class="card center">
                    <div class="card-content  green white-text">
                        <p class="card-stats-title center"><i class="mdi-social-group-add"></i>New Users</p>
                        <h4 class="card-stats-number" id="usersCount" runat="server">566</h4>
                        <p class="card-stats-compare">
                            <i class="mdi-hardware-keyboard-arrow-up"></i>15% <span class="green-text text-lighten-5">from yesterday</span>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col s4">
                <div class="card center">
                    <div class="card-content  purple white-text">
                        <p class="card-stats-title center"><i class="mdi-editor-insert-drive-file"></i>New Stories</p>
                        <h4 class="card-stats-number" id="storiesCount" runat="server">100</h4>
                        <p class="card-stats-compare center">
                            <i class="mdi-hardware-keyboard-arrow-up"></i>5% <span class="green-text text-lighten-5">from yesterday</span>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col s3 center">
                <div class="card center">
                    <div class="card-content blue-grey white-text">
                        <p class="card-stats-title center"><i class="mdi-action-trending-up"></i>New Donation</p>
                        <h4 class="card-stats-number" id="donationCount" runat="server">345</h4>
                        <p class="card-stats-compare">
                            <i class="mdi-hardware-keyboard-arrow-up"></i>12% <span class="green-text text-lighten-5">from yesterday</span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="row center">
            <div class="col offset-l1 s3">
                <a href="UsersPanel.aspx" class="waves-effect waves-light btn-large"><i class="material-icons left">perm_identity</i>Users</a>
            </div>
            <div class="col s4">
                <a href="StoriesApproval.aspx" class="waves-effect waves-light btn-large"><i class="material-icons left">done</i>Stories Approval</a>
            </div>
            <div class="col s3">
                <a href="StoriesPanel.aspx" class="waves-effect waves-light btn-large"><i class="material-icons left">description</i>Stories</a>
            </div>
        </div>
    </div>
</asp:Content>
