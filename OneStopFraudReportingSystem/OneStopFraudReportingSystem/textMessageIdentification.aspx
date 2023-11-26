<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="textMessageIdentification.aspx.cs" Inherits="OneStopFraudReportingSystem.textMessageIdentification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <style>
        .word{
            color:red;
        }

        .word1{
            font-family: 'Times New Roman', Times, serif;
            font-size: 18px;
        }
    </style>

    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ImagePreview(input) {
            if (input.files && input.files[0])
            {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=MyImage.ClientID%>').prop('src', e.target.result)
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

    <div class="container">
        <div>
            <div class="row">
                <div class="col-md-7 mx-auto">
                    <div class="card-body" style="background-clip: border-box; border: 1px solid rgba(0,0,0, .125); border-radius: .25rem;">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/message-identify.jpg" width="150" height="150"/>
                                    <h4>Text Message Identification</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Panel ID="ImagePanel" runat="server" Height="375px">
                                        <asp:Image ID="MyImage" runat="server" Height="350px" Width="350px"/>
                                    </asp:Panel>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <asp:FileUpload CssClass="btn btn-primary btn-block btn-lg" ID="FileUpload1" runat="server" inputtype="image" OnChange="ImagePreview(this);"/>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" Display="Dynamic" ErrorMessage="Please Upload Screenshotted Text Message!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <!--<asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="btnUpload" runat="server" Text="Choose File" OnChange="ImagePreview(this);" OnClick="btnUpload_Click"/>-->
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="btn-block" ID="ImagePath" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
                                    </div>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="resultTest" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                    </div>
                                </center>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />

    <hr />

    <div class="container">
        <div class="row">
            <div class="col">
                <center>
                    <h3>User Guide on Message Identification</h3>
                </center>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col">
                <h4>1. Upload the screenshotted text message.</h4>
                <h4>2. Click on the submit button and wait for the result.</h4>
                <h4>3. If there is a fraud message, the system will encourage the user to make a reporting.</h4>
                <h4>4. Login with your account, if you plan to make a reporting.</h4>
                <h4>5. If you did not have an account, you need to create a new USER ACCOUNT.</h4>
            </div>
        </div>
    </div>
</asp:Content>
