using NorthwindProject.BusinessLayer;
using NorthwindProject.BusinessLayer.DTO;
using NorthwindProject.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PopulateGridViewCategory();
        }


        private IEnumerable<ProductDto> GetProducts()
        {
            var op = new GetAllProductsOperation();
            var result = OperationManager.Instance.ExecuteOperation(op).Data as IEnumerable<ProductDto>;

            return result;
        }
        private IEnumerable<CategoryDto> GetCategories()
        {
            var op = new GetAllCategoriesOperation();
            var result = OperationManager.Instance.ExecuteOperation(op).Data as IEnumerable<CategoryDto>;


            return result;
        }
        private void PopulateGridViewProducts()
        {

            var products = GetProducts();
            this.dgvProducts.DataSource = products;
        }
        private void PopulateGridViewCategory()
        {
            var categories = GetCategories();
            this.dgvCategories.DataSource = categories;
        }



        private void btnInsert_Click(object sender, EventArgs e)
        {
            var form = new InsertProductForm();
            form.Show();
            form.Disposed += InsertProductForm_Disposed;
        }

        private void InsertProductForm_Disposed(object sender, EventArgs e)
        {
            PopulateGridViewWithSpecificProducts();
        }

        private void PopulateGridViewWithSpecificProducts()
        {
            var selectedCategory = this.dgvCategories.SelectedRows[0].DataBoundItem as CategoryDto;

            var id = selectedCategory.Id;

            var op = new GetAllProductsOperation(id);
            var result = OperationManager.Instance.ExecuteOperation(op);

            if (result.IsSuccessful)
            {
                var data = result.Data as IEnumerable<ProductDto>;
                this.dgvProducts.DataSource = data;
            }
            else
            {
                MessageBox.Show(result.Errors.First());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvProducts.SelectedRows.Count == 1)
            {
                var selectedProduct = this.dgvProducts.SelectedRows[0].DataBoundItem as ProductDto;

                var updateForm = new UpdateProductForm(selectedProduct);
                updateForm.Show();

                updateForm.Disposed += UpdateProductForm_Disposed;
            }
            else
            {
                MessageBox.Show("You need to select one row");
            }
        }


        private void UpdateProductForm_Disposed(object sender, EventArgs e)
        {
            PopulateGridViewWithSpecificProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedProducts = this.dgvProducts.SelectedRows;

            var idsToDelete = new List<int>();

            for (int i = 0; i < selectedProducts.Count; i++)
            {
                idsToDelete.Add((selectedProducts[i].DataBoundItem as ProductDto).Id);
            }

            var opd = new DeleteProductOperation(idsToDelete);
            var result = OperationManager.Instance.ExecuteOperation(opd);
            if (result.IsSuccessful)
            {
                MessageBox.Show("Successfuly deleted!");
                PopulateGridViewWithSpecificProducts();
            }
            else
            {
                MessageBox.Show(result.Errors.First());

            }
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateGridViewWithSpecificProducts();
        }
    }
}
