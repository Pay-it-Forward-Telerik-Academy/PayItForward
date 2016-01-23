<%@ Page Title="Create new story" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Create.aspx.cs" Inherits="PayItForward.WebForms.Story.CreateStory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col s8 offset-s2">
            <div class="card-panel z-depth-4">
                <div class="form-horizontal">
                    <h4><%: Title %></h4>
                    <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="row">
                        <div class="col s6">
                               <label for="email">Title</label>
                            <asp:TextBox runat="server" ID="TitleStory" TextMode="SingleLine" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TitleStory"
                                CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s6">
                            <asp:Label runat="server" AssociatedControlID="DropDownListCategories" CssClass="col-md-3 control-label">Category</asp:Label>
                            <asp:DropDownList ID="DropDownListCategories" runat="server" DataTextField="Name" DataValueField="Id" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col s6 input-field">
                            <asp:TextBox runat="server" ID="GoalAmount" CssClass="form-control" Placeholder="Enter a goal amount(required)" TextMode="Number" />
                            <asp:Label runat="server" AssociatedControlID="GoalAmount" CssClass="col-md-3 control-label">GoalAmount</asp:Label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="GoalAmount"
                                CssClass="text-danger" ErrorMessage="Please specify goal amount of the story!" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="EstimatedDays" CssClass="col-md-3 control-label">EstimatedDays</asp:Label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="EstimatedDays" CssClass="form-control" Placeholder="Enter a EstimatedDays" TextMode="Number" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="EstimatedDays"
                                        CssClass="text-danger" ErrorMessage="Please specify goal amount of the story!" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-3 control-label">Description</asp:Label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="Description" CssClass="form-control" Placeholder="Enter a story's description (optional)" TextMode="MultiLine" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col s5 offest-s2">
                            <div class="file-field input-field">
                                <input class="file-path validate valid" type="text">
                                <div class="btn">
                                    <span>Image</span>
                                    <asp:FileUpload ID="Image" runat="server" accept="image/*" />
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Image"
                                    CssClass="text-danger" ErrorMessage="Please chose cover image!" />
                            </div>
                        </div>
                        <div class="col s5 offest-s2">
                            <div class="file-field input-field">
                                <input class="file-path validate valid" type="text">
                                <div class="btn">
                                    <span>Confirmation File</span>
                                    <asp:FileUpload ID="Document" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Document"
                                    CssClass="text-danger" ErrorMessage="Please chose valid document that confirm this story!" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-offset-3 col-md-9">
                                <asp:Button runat="server" OnClick="OnCreateStoryButtonClicked" Text="Create Story" CssClass="btn btn-default" />
                            </div>
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

