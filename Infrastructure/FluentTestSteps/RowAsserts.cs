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

        public RowAssertActions<TCurrentRow> IsVisible()
        {
            Assert.That(_row.IsFullyInView, Is.True, "Row is not fully visible");

            return this;
        }

        public RowAssertActions<TCurrentRow> ValueInColumn(int columnIndex, Constraint constraint)
        {
            Assert.That(
                _row.ValueInColumn(columnIndex), 
                constraint, 
                $"Invalid value in cell at column {columnIndex + 1 }"
            );

            return this;
        }

    }
}
