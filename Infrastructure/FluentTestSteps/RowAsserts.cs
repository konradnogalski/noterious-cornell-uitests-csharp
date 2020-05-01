using Infrastructure.PageObject.PageElements;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Infrastructure.FluentTestSteps
{
    public class RowAssertActions<TCurrentRow> where TCurrentRow : Row
    {
        private Row _row;
        public RowAssertActions(Row row)
        {
            _row = row;
        }

        public void ValueInColumn(int columnIndex, Constraint constraint)
        {
            Assert.That(
                _row.ValueInColumn(columnIndex), 
                constraint, 
                $"Invalid value in cell at column {columnIndex + 1 }"
            );
        }

    }
}
