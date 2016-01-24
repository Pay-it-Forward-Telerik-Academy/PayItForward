<%@ Page Title="Create new story" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Create.aspx.cs" Inherits="PayItForward.WebForms.Story.CreateStory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col s8 offset-s2">
            <div class="card-panel z-depth-4">
                <div>
                    <h4 class="center"><%: Title %></h4>
                    <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="row">
                        <div class="input-field col offset-s2 s8">
                            <i class="material-icons prefix">description</i>
                            <asp:TextBox runat="server" ID="TitleStory" TextMode="SingleLine" CssClass="form-control" />
                            <label for="email">Title</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TitleStory"
                                CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col offset-s2 s8">
                            <i class="material-icons prefix">list</i>
                            <asp:DropDownList ID="DropDownListCategories" runat="server" DataTextField="Name" DataValueField="Id" CssClass="dropdown-category"></asp:DropDownList>
                            <label for="email">Category</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col offset-s2 s8 input-field">
                            <i class="material-icons prefix">payment</i>
                            <asp:TextBox runat="server" ID="GoalAmount" CssClass="form-control" Placeholder="Enter a goal amount(required)" TextMode="Number" />
                            <label for="email">Goal Amount</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="GoalAmount"
                                CssClass="text-danger" ErrorMessage="Please specify goal amount of the story!" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col offset-s2 s8 input-field">
                            <i class="mdi-notification-event-available prefix"></i>
                            <asp:TextBox runat="server" ID="EstimatedDays" CssClass="form-control" Placeholder="Enter a EstimatedDays" TextMode="Number" />
                            <label for="email">Estimated Days</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="EstimatedDays"
                                CssClass="text-danger" ErrorMessage="Please specify goal amount of the story!" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col offset-s2 s8">
                            <i class="mdi-communication-comment prefix"></i>
                            <textarea runat="server" id="Description" length="120" class="materialize-textarea"></textarea>
                            <label for="textarea1" class="">Description</label>
                        </div>
                    </div>

                    <div class="row center">
                        <div class="col s5 offset-s1">
                            <div class="row center">
                                <div class="file-field input-field">
                                    <div class="col s6">
                                        <input class="file-path validate valid" type="text">
                                        <label for="Image">Image</label>
                                    </div>
                                    <div class="col s5">
                                        <span class="btn-floating">
                                            <i class="mdi-image-photo-camera"></i>
                                            <asp:FileUpload ID="Image" runat="server" accept="image/*" />
                                        </span>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Image"
                                            CssClass="text-danger" ErrorMessage="Please chose cover image!" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col s5 offset-s1">
                            <div class="row center">
                                <div class="file-field input-field">
                                    <div class="col s6">
                                        <input class="file-path validate valid" type="text">
                                        <label for="Document">Document</label>
                                    </div>
                                    <div class="col s6">
                                        <span class="btn-floating">
                                            <i class="mdi-action-description"></i>
                                            <asp:FileUpload ID="Document" runat="server" />
                                        </span>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Document"
                                            CssClass="text-danger" ErrorMessage="Please chose valid document that confirm this story!" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="center">
                            <asp:Button runat="server" OnClick="OnCreateStoryButtonClicked" Text="Create Story" CssClass="btn waves-effect waves-light btn waves-input-wrapper green accent-4" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
    $(document).ready(function () {
        $('select').material_select();
    });
    </script>
</asp:Content>

