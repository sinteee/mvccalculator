using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace EmployeExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        public interface IRepository<TEntity>
        {
            void Add(TEntity entity);
            void Edit(TEntity entity, int id);
            void Delete(int id);
            TEntity FindById(int id);
            IEnumerable<TEntity> GetAll();


          

        }
        public class Commander<TEntity> : IRepository<TEntity> where TEntity : class
        {
            DbContext context;
            public void Add(TEntity entity)
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }

            public void Delete(int id)
            {
               TEntity entity = this.FindById(id);
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }

            public void Edit(TEntity entity, int id)
            {
                entity = this.FindById(id);
                context.SaveChanges();
            }

            public TEntity FindById(int id)
            {
                return context.Set<TEntity>().Find(id);
            }

            public IEnumerable<TEntity> GetAll()
            {
                return context.Set<TEntity>().ToList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
