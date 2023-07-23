<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookStore.aspx.cs" Inherits="BookStore.BookStore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Store Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h1><b>Book Store Details</b></h1>
         
            <asp:Label runat="server"><b>Book Name   :</b>&nbsp&nbsp</asp:Label>
            <asp:TextBox runat="server" id="BookName" placeholder="Enter Book Name" OnTextChanged="BookName_TextChanged" style="margin-left: 21px" Width="311px"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server"><b>Author Name  :</b>&nbsp&nbsp</asp:Label>
            <asp:TextBox runat="server" id="Authorid" placeholder="Enter Author Name" style="margin-left: 7px" Width="304px"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server"><b>No of Books :</b>&nbsp&nbsp</asp:Label>
            <asp:TextBox runat="server" id="NoBoks" style="margin-left: 15px" Width="221px"></asp:TextBox>
            <br />
            <br />
            <asp:Button runat="server" style="margin-left: 101px;" Text="Insert" ID="Submit" OnClick="Add_onclick" BorderColor="Red" BorderStyle="Double" Font-Bold="True" Font-Size="11pt" Height="39px" Width="125px" BackColor="#CC3300" ForeColor="Black"/>
            <asp:Button ID="btnclear" runat="server" BackColor="#CC3300" BorderColor="Red" Height="38px" style="margin-left: 44px" Text="Clear" Width="149px" OnClick="btnclear_Click" />
            <br />
            <br />
            


            <asp:DataGrid runat="server" ID="BkStore" AutoGenerateColumns="false" Width="732px">
                  <Columns>  
                        <asp:BoundColumn HeaderText="BookName" DataField="BookName"> </asp:BoundColumn>  
                        <asp:BoundColumn HeaderText="AuthorName" DataField="AuthorName"> </asp:BoundColumn>  
                        <asp:BoundColumn HeaderText="NoofBooks" DataField="NoofBooks"> </asp:BoundColumn>  
                       <asp:TemplateColumn >
                          <ItemTemplate>
                              <asp:LinkButton ID="btnUpdate" Text="Update" runat="server" CommandArgument='<% # Eval("Bkid") %>' OnClick="btnUpdate_Click1"></asp:LinkButton>
                          </ItemTemplate>
                       </asp:TemplateColumn>  
                         <asp:TemplateColumn >
                          <ItemTemplate>
                              <asp:LinkButton ID="BtnDelete" Text="Delete" runat="server" CommandArgument='<% # Eval("Bkid") %>' OnClick="BtnDelete_Click"></asp:LinkButton>
                          </ItemTemplate>
                       </asp:TemplateColumn> 
                    </Columns> 
                 <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />  
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />  
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />  
                    <AlternatingItemStyle BackColor="White" />  
                    <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />  
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" /> </asp:DataGrid> <br /> <br /> 

           

 


            

        </div>
        
    </form>
</body>
</html>
