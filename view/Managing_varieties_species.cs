using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace PharmacySystem.view
{
    public partial class Managing_varieties_species: Form
    {
        List<category> allCategories = new List<category>();
        List<company> allcompanies = new List<company>();
        List<Type> allType = new List<Type>();
        public Managing_varieties_species()
        {
            InitializeComponent();
            getAllCategories();
            getAllType();
            getAllCompainy();
            this.menuStrip1.Items.Add(MinuStripMain.instance());
            /*
            btnAddCat.Enabled = false;
            btnAddType.Enabled = false;
            btnCompanies.Enabled = false;
            typedataGridView.ClearSelection();
            */
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void categroies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int savedCount = 0;
            int editCount = 0;
            int removed = 0;
            try
            {
                var companiesToUpdate = new Dictionary<int, (string name, string country)>();
                var companiesToAdd = new List<company>();

                foreach (DataGridViewRow row in compainydataGridView.Rows)
                {
                    if (row.IsNewRow) continue;

                    string compName = row.Cells[2].Value?.ToString()?.Trim();
                    string compCountry = row.Cells[1].Value?.ToString()?.Trim();

                    if (int.TryParse(row.Cells[0].Value?.ToString(), out int id))
                    {
                        if (!string.IsNullOrEmpty(compName))
                            companiesToUpdate[id] = (compName, compCountry);
                    }
                    else if (!string.IsNullOrEmpty(compName))
                    {
                        companiesToAdd.Add(new company
                        {
                            name = compName,
                            country = compCountry
                        });
                    }
                }
                using (var db = new DataBaseConnection())
                {

                    if (companiesToUpdate.Count > 0)
                    {
                        var ids = companiesToUpdate.Keys.ToList();
                        var existingCompanies = db.companies
                            .Where(c => ids.Contains(c.company_id))
                            .ToDictionary(c => c.company_id);
                        var removedCompanies = db.companies
                            .Where(c => !ids.Contains(c.company_id))
                            .ToList();
                        if(removedCompanies.Count > 0)
                        {
                            removed = removedCompanies.Count;
                            db.companies.RemoveRange(removedCompanies);
                        }

                        foreach (var kvp in companiesToUpdate)
                        {
                            if (existingCompanies.TryGetValue(kvp.Key, out var company))
                            {
                                company.name = kvp.Value.name;
                                company.country = kvp.Value.country;
                                editCount++;
                            }
                        }
                    }

                    if (companiesToAdd.Count > 0)
                    {
                        db.companies.AddRange(companiesToAdd);
                        savedCount = companiesToAdd.Count;
                    }

                    db.SaveChanges();
                }

                MessageBox.Show($"تم اضافة {savedCount} صف وتم تعديل {editCount}" + (removed > 0 ? $"وتم حذف {removed}" : ""));
                compainydataGridView.Rows.Clear();
                getAllCompainy();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void getAllCategories()
        {
            using (var db = new DataBaseConnection())
            {
                 allCategories = db.categories.Include(c=>c.medicines).ToList();
                
                if (allCategories != null)
                {
                    //categroiesDataGrade.Rows.Clear();
                    foreach (var cat in allCategories)
                    {
                        categroiesDataGrade.Rows.Add(cat.category_id, cat.name);
                    }
                }
            }
        }

        private void getAllType()
        {
            using (var db = new DataBaseConnection())
            {
                
                    allType = db.Types.Include(c => c.medicines).ToList();

                    if (allType != null)
                    {
                        //categroiesDataGrade.Rows.Clear();
                        foreach (var cat in allType)
                        {
                            typedataGridView.Rows.Add(cat.type_id, cat.name);
                        }
                    }
                }
            }
        private void getAllCompainy()
        {
            using (var db = new DataBaseConnection())
            {
                allcompanies = db.companies.Include(c => c.medicines).ToList();

                if (allcompanies != null)
                {
                    //categroiesDataGrade.Rows.Clear();
                    foreach (var cat in allcompanies)
                    {
                        compainydataGridView.Rows.Add(cat.company_id, cat.country,cat.name);
                    }
                }
                //this.compainydataGridView.RowsAdded += (sender, e) =>
                //{
                //    var newRow = compainydataGridView.Rows[e.RowIndex];
                //    string country = newRow.Cells[1].Value?.ToString();
                //    string name = newRow.Cells[2].Value?.ToString();
                //    if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(country))
                //        db.companies.Add(new company() {
                //            name = name,
                //            country = country,
                //        });
                //};
            }

        }

        private void BtnAddType_Click(object sender, EventArgs e)
        {
            int savedCount = 0;
            int editCount = 0;
            int removed = 0;
            try
            {
                var typesToUpdate = new Dictionary<int, string>();
                var typesToAdd = new List<Type>();

                foreach (DataGridViewRow row in typedataGridView.Rows)
                {
                    if (row.IsNewRow) continue;

                    string typeName = row.Cells[1].Value?.ToString()?.Trim();

                    if (int.TryParse(row.Cells[0].Value?.ToString(), out int id))
                    {
                        if (!string.IsNullOrEmpty(typeName))
                            typesToUpdate[id] = (typeName);
                    }
                    else if (!string.IsNullOrEmpty(typeName))
                    {
                        typesToAdd.Add(new Type
                        {
                            name = typeName
                        });
                    }
                }
                using (var db = new DataBaseConnection())
                {

                    if (typesToUpdate.Count > 0)
                    {
                        var ids = typesToUpdate.Keys.ToList();
                        var existingtypes = db.Types
                            .Where(c => ids.Contains(c.type_id))
                            .ToDictionary(c => c.type_id);
                        var deletedTypes = db.Types
                            .Where(c => !ids.Contains(c.type_id))
                            .ToList();
                        if(deletedTypes.Count > 0)
                        {
                            removed = deletedTypes.Count;
                            db.Types.RemoveRange(deletedTypes);
                        }
                        foreach (var kvp in typesToUpdate)
                        {
                            if (existingtypes.TryGetValue(kvp.Key, out var type))
                            {
                                type.name = kvp.Value;
                                editCount++;
                            }
                        }
                    }

                    if (typesToAdd.Count > 0)
                    {
                        db.Types.AddRange(typesToAdd);
                        savedCount = typesToAdd.Count;
                    }

                    db.SaveChanges();
                }

                MessageBox.Show($"تم اضافة {savedCount} صف وتم تعديل {editCount}" + (removed > 0 ? $"وتم حذف {removed}" : ""));
                typedataGridView.Rows.Clear();
                getAllType();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
        }

        private void BtnAddCat_Click(object sender, EventArgs e)
        {
            int savedCount = 0;
            int editCount = 0;
            int removed = 0;
            try
            {
                var categoriesToUpdate = new Dictionary<int, string>();
                var categoriesToAdd = new List<category>();

                foreach (DataGridViewRow row in categroiesDataGrade.Rows)
                {
                    if (row.IsNewRow) continue;

                    string catName = row.Cells[1].Value?.ToString()?.Trim();

                    if (int.TryParse(row.Cells[0].Value?.ToString(), out int id))
                    {
                        if (!string.IsNullOrEmpty(catName))
                            categoriesToUpdate[id] = (catName);
                    }
                    else if (!string.IsNullOrEmpty(catName))
                    {
                        categoriesToAdd.Add(new category
                        {
                            name = catName
                        });
                    }
                }
                using (var db = new DataBaseConnection())
                {

                    if (categoriesToUpdate.Count > 0)
                    {
                        var ids = categoriesToUpdate.Keys.ToList();
                        var existingcategories = db.categories
                            .Where(c => ids.Contains(c.category_id))
                            .ToDictionary(c => c.category_id);
                        var deletedCategories = db.categories
                            .Where(c => !ids.Contains(c.category_id))
                            .ToList();
                        if (deletedCategories.Count > 0)
                        {
                            removed = deletedCategories.Count;
                            db.categories.RemoveRange(deletedCategories);
                        }
                        foreach (var kvp in categoriesToUpdate)
                        {
                            if (existingcategories.TryGetValue(kvp.Key, out var type))
                            {
                                type.name = kvp.Value;
                                editCount++;
                            }
                        }
                    }

                    if (categoriesToAdd.Count > 0)
                    {
                        db.categories.AddRange(categoriesToAdd);
                        savedCount = categoriesToAdd.Count;
                    }

                    db.SaveChanges();
                }

                MessageBox.Show($"تم اضافة {savedCount} صف وتم تعديل {editCount}" + (removed > 0? $"وتم حذف {removed}": ""));
                categroiesDataGrade.Rows.Clear();
                getAllCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
            //using (var db = new DataBaseConnection())
            //{
            //    int savedCout = 0;
            //    for (int i = 0; i < typedataGridView.Rows.Count - 1; i++)
            //    {
            //        DataGridViewRow row = typedataGridView.Rows[i];
            //        string catName = row.Cells["Type_name"].Value?.ToString();
            //        //string compCountry = row.Cells["country"].Value?.ToString();
            //        if (!string.IsNullOrWhiteSpace(catName))
            //        {
            //            var newType = new Type()
            //            {
            //                name = catName

            //            };
            //            db.categories.Add(newType);
            //            savedCout++;
            //        }
            //    }
            //    db.SaveChanges();
            //}
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
        private void TypedataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnAddType.Enabled = true;
        }

        private void Companies_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = Companies_search.Text.Trim().ToLower();

            var filtered = allcompanies.Where(c => c.name != null && c.
            name.ToLower().Contains(keyword)).ToList();

            compainydataGridView.Rows.Clear();
            foreach (var cat in filtered)
            {
                compainydataGridView.Rows.Add(cat.company_id, cat.country,cat.name);
            }
        }

        private void Categories_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = Categories_search.Text.Trim().ToLower();

            var filtered = allCategories.Where(c => c.name != null && c.
            name.ToLower().Contains(keyword)).ToList();

            categroiesDataGrade.Rows.Clear();
            foreach(var cat in filtered)
            {
                categroiesDataGrade.Rows.Add(cat.category_id, cat.name);
            }

            
        }

        private void Types_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = Types_search.Text.Trim().ToLower();

            var filtered = allType.Where(c => c.name != null && c.
            name.ToLower().Contains(keyword)).ToList();

            typedataGridView.Rows.Clear();
            foreach (var cat in filtered)
            {
                typedataGridView.Rows.Add(cat.type_id, cat.name);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
