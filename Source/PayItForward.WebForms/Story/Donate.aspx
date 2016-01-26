<%@ Page Title="Donate" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Donate.aspx.cs"
    Inherits="PayItForward.WebForms.Donate" %>

<asp:Content ID="Donate" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col s6">
            <div class="card-panel z-depth-4">
                <h4>Enter your donation</h4>
                <div class="row">
                    <div class="input-field col s12">
                        <i class="material-icons prefix">payment</i>
                        <asp:TextBox runat="server" ID="Amount" TextMode="Number" row="3" />
                        <label for="Amount">Enter your donation</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Amount"
                            ForeColor="Red" ErrorMessage="You must fill amout field." />
                    </div>
                </div>

                <asp:Label runat="server" AssociatedControlID="DropDownListCountries">Country</asp:Label>
                <asp:DropDownList ID="DropDownListCountries" runat="server"></asp:DropDownList>

                <div class="row">
                    <div class="input-field col s12">
                        <i class="mdi-action-account-circle prefix"></i>
                        <asp:TextBox runat="server" ID="Username" CssClass="form-control" TextMode="SingleLine" />
                        <label for="email">Your Name</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                            ForeColor="Red" ErrorMessage="The email field is required." />
                    </div>
                </div>

                <div class="row">
                    <div class="input-field col s12">
                        <i class="mdi-communication-email prefix"></i>
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <label for="email">Your Email</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                           ForeColor="Red" ErrorMessage="The email field is required." />
                    </div>
                </div>

                <div class="center">
                    <asp:Button runat="server" OnClick="CreateDonation" Text="Donate" CssClass="waves-effect waves-light btn" />
                </div>
            </div>
        </div>

        <div class="card col s6 card-panel z-depth-4">
            <div class="card-image">
                <img id="storyImage" runat="server" alt="sample image"/>

                <span runat="server" class="card-title" id="cardTitle"></span>
            </div>
            <div class="card-content">
                <p runat="server" id="Description"></p>
            </div>
            <div class="center">
                <span id="collectedAmount" runat="server"></span>
                <span> of </span>
                <span id="goalAmount" runat="server"></span>
            </div>
            <div class="progress">
                <div class="determinate" id="progressBar" runat="server"></div>
            </div>
            <div class="card-action">
                <a runat="server" id="storyDetails">Details</a>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('select').material_select();
        });
    </script>
</asp:Content>
