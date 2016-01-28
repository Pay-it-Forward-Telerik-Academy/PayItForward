<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PayItForward.WebForms.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="row">
        <div class="col s6 offset-s3">
            <div class="card-panel z-depth-4">
                <section id="loginForm">
                    <div class="form-horizontal">
                        <h4>Log In</h4>
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                        <div class="row">
                            <div class="input-field col s12">
                                <i class="mdi-action-account-circle prefix"></i>
                                <asp:TextBox runat="server" ID="Username" CssClass="form-control" TextMode="SingleLine" />
                                <label for="Username">Username</label>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                                    ForeColor="Red" ErrorMessage="The usename field is required." />
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <div class="col-md-10">
                                    <i class="mdi-action-lock-outline prefix"></i>
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                    <label for="Password">Password</label>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ForeColor="Red" ErrorMessage="The password field is required." />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <div class="checkbox">
                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                    <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="center">
                            <asp:Button runat="server" OnClientClick="Materialize.toast('You login successfully!', 2000)" OnClick="LogIn" Text="Log in" CssClass="waves-effect waves-light btn" />
                        </div>
                    </div>
                    <p>
                        <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                    </p>
                    <p>
                        <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                        --%>
                    </p>
                </section>
            </div>
        </div>

    </div>
</asp:Content>
