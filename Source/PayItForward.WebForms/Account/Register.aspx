<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PayItForward.WebForms.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="row">
        <div class="col s6 offset-s3">
            <div class="card-panel z-depth-4">
                <h4>Register</h4>
                <div class="row">
                    <div class="input-field col s12">
                        <i class="mdi-action-account-circle prefix"></i>
                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control" TextMode="SingleLine" />
                        <label for="email">Username</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                           ForeColor="Red" ErrorMessage="The username field is required." />
                    </div>
                </div>

                <div class="row">
                    <div class="input-field col s12">
                        <i class="mdi-communication-email prefix"></i>
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <label for="email">Email</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                           ForeColor="Red" ErrorMessage="The email field is required." />
                    </div>
                </div>

                <div class="row">
                    <div class="input-field col s12">
                        <i class="mdi-action-lock-outline prefix"></i>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <label for="email">Password</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                            ForeColor="Red" ErrorMessage="The password field is required." />
                    </div>
                </div>

                <div class="row">
                    <div class="input-field col s12">
                        <i class="mdi-action-lock-outline prefix"></i>
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                            ForeColor="Red" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                        <label for="email">Confirm Password</label>
                        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                            Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                    </div>
                </div>
                <div class="center">
                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="waves-effect waves-light btn" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
