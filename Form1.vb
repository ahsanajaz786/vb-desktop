Imports System.Data.SqlClient
Imports System
Imports System.Data




Public Class Form1
    Dim id As String = ""

    Dim con As New SqlConnection("Data Source=DESKTOP-7C7BH2I;Initial Catalog=vbcrud;Integrated Security=True")


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim itemName As String = txt_pname.Text
        Dim itemColor As String = txt_color.Text
        Dim design As String = txt_desgin.Text
        Dim insertedDate As String = Date.Now


        Dim warrenty As String = ""

        If txt_allow.Checked = True Then
            warrenty = "Allowed"
        Else
            warrenty = "Not Allowed"



        End If



        con.Open()
        Dim command As New SqlCommand("insert into Product_Setup values('" + itemName + "','" + design + "','" & itemColor + "','" + insertedDate + "','" + warrenty + "') ", con)
        command.ExecuteNonQuery()
        MessageBox.Show("Successfully added")
        txt_pname.Text = ""
        txt_color.Text = ""
        txt_desgin.Text = ""
        con.Close()

        LoadDataGrid()


    End Sub
    Private Sub LoadDataGrid()
        Dim command As New SqlCommand("select * from Product_Setup", con)
        Dim sda As New SqlDataAdapter(command)
        Dim dt = New DataTable
        sda.Fill(dt)
        DataGridView1.DataSource = dt





    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Visible = False

        LoadDataGrid()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick


        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        txt_pname.Text = row.Cells(1).Value
        id = row.Cells(0).Value

        txt_desgin.Text = row.Cells(2).Value
        txt_color.Text = row.Cells(3).Value
        Dim allow As String = row.Cells(5).Value

        Button2.Visible = True
        If allow = "Allowed" Then
            txt_allow.Checked = True
        Else
            txt_unallow.Checked = True



        End If






    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Visible = False
        Dim itemName As String = txt_pname.Text
        Dim itemColor As String = txt_color.Text
        Dim design As String = txt_desgin.Text
        Dim insertedDate As String = Date.Now


        Dim warrenty As String = ""

        If txt_allow.Checked = True Then
            warrenty = "Allowed"
        Else
            warrenty = "Not Allowed"



        End If



        con.Open()
        Dim command As New SqlCommand("update  Product_Setup set ItemName='" + itemName + "',Design='" + design + "',Color='" + itemColor + "',WarentyType='" + warrenty + "' where productId='" + id + "' ", con)
        command.ExecuteNonQuery()
        MessageBox.Show("Successfully updated")
        txt_pname.Text = ""
        txt_color.Text = ""
        txt_desgin.Text = ""
        con.Close()

        LoadDataGrid()




    End Sub
End Class
