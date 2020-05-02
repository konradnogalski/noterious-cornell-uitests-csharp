using Infrastructure.PageObject.PageElements;
using System;

namespace Infrastructure.FluentTestSteps
{
    public class TableFluentActions<TCurrentTable> where TCurrentTable : Table
    {
        private readonly TCurrentTable _table;
        public TableFluentActions(TCurrentTable table)
        {
            _table = table;
        }

        public TableFluentActions<TCurrentTable> InRow<TCurrentRow>(TCurrentRow row, Action<RowActions<TCurrentRow>> rowActions)
        where TCurrentRow : Row
        {
            if (!row.IsFullyInView)
            {
                row.scrollIntoView();
            }
            
            rowActions.Invoke(new RowActions<TCurrentRow>(row));

            return this;
        }
    }
}
