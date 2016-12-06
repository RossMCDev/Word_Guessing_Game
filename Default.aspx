<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Word Guessing</title>
        <link rel="stylesheet"  href="bootstrap.css"/>
	<link rel="stylesheet" type="text/css" href="site.css"/>
</head>
<body>

    <div id ="focus">
    <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <br/>                        <br/>           
       


     
                 
             
        <asp:Button ID="ButtonStart" runat="server" Text="Start Game" OnClick="ButtonStart_Click" CssClass="btn-lg" Font-Size="X-Large" Height="60px" Width="148px"/>
        <asp:Label ID="LabelCategories" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Set category:&nbsp;" Font-Size="Large"></asp:Label>
        <asp:DropDownList ID="DropDownListCategories" runat="server" Font-Size="Large">
            <asp:ListItem>Animals</asp:ListItem>
            <asp:ListItem>Plants</asp:ListItem>
            <asp:ListItem>Space</asp:ListItem>
            <asp:ListItem>Hot Drinks</asp:ListItem>
            <asp:ListItem>Music Composition</asp:ListItem>
        </asp:DropDownList>
     <asp:Panel ID="Panel1" runat="server" DefaultButton="ButtonGuess">
    <asp:TextBox ID="TextBoxGuess" runat="server" pattern="[A-Za-z]{1}" Font-Size="XX-Large" Width="70px" Visible="False" CssClass="input-sm" Height="50px" autofocus ="true" MaxLength="1" oninvalid="setCustomValidity('Only enter letters from the english alpabet')"
        onkeyup ="setCustomValidity('')">

    </asp:TextBox>
    <asp:Button ID="ButtonGuess" runat="server" Text="Make Guess" Height="60px" Width="128px" Visible="False" OnClick="ButtonGuess_Click" CssClass="btn-lg" />
 </asp:Panel>
         

    <asp:Label ID="LabelWordToGuess" runat="server" Font-Names="MV Boli">Hangman</asp:Label>
  <br/>
       <br/>
           <asp:Label ID="LabelStatus" runat="server"></asp:Label>
                    <br/>
    <asp:Image ID="ImageBase" runat="server" ImageUrl="~/Images/State0.png" CssClass="image" />
    <br/>
    <asp:Label ID="LabelMissWords" runat="server" Text="Letters:" Visible="False" BorderStyle="None"></asp:Label>
            <br />
            <br/>
    <asp:Button ID="ButtonGiveUp" runat="server" Text="Give Up" Visible="False" OnClick="ButtonGiveUp_Click" CssClass="btn-danger" novalidate ="true"/>
    <br/><br/><br/><br/><br/>
        <br />
        <br/>  

    <%--              </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
        </div>
</body>
</html>
