using NorthwindProject.BusinessLayer;
using NorthwindProject.BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindProject.Forms
{
    public partial class InsertProductForm : Form
    {
        public InsertProductForm()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            var categories = GetCategories();
            var suppliers = GetSuppliers();
            PopulateComboBoxes(this.ddlCategory, categories);
            PopulateComboBoxes(this.ddlSupplier, suppliers);
        }

        private IEnumerable<CategoryDto> GetCategories()
        {
            var catOp = new GetAllCategoriesOperation();
            return OperationManager.Instance.ExecuteOperation(catOp).Data as IEnumerable<CategoryDto>;
        }

        private IEnumerable<SupplierDto> GetSuppliers()
        {
            var supOp = new GetAllSuppliersOperation();
            return OperationManager.Instance.ExecuteOperation(supOp).Data as IEnumerable<SupplierDto>;
        }
        private void PopulateComboBoxes(ComboBox c, IEnumerable<Dto> dto)
        {
            c.ValueMember = "Id";
            c.DisplayMember = "Name";
            c.DataSource = dto;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var name = this.tbName.Text;
            var discountinued = this.chbDiscountinued.Checked;
            var categoryId = this.ddlCategory.SelectedValue;
            var supplierId = this.ddlSupplier.SelectedValue;


            var addProductDto = new InsertProductDto
            {
                Name = name,
                Discountinued = discountinued,
                CategoryId = (int)categoryId,
                SupplierId = (int)supplierId
            };

            var op = new InsertProductOperation(addProductDto);
            var result = OperationManager.Instance.ExecuteOperation(op);

            if (!result.Errors.Any())
            {
                MessageBox.Show("Successfuly added!");
                RefreshGrid();
            }
            else
            {
                MessageBox.Show(result.Errors.First());
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
