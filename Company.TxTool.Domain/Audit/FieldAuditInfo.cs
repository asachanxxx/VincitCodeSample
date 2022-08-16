using System;

namespace Cushwake.TreasuryTool.Domain.Audit
{
    public class FieldAuditInfo
    {
        private List<SimpleFieldAuditInfo> _simpleAudits = new List<SimpleFieldAuditInfo>();
        private List<ComplexFieldAuditInfo> _complexAudits = new List<ComplexFieldAuditInfo>();

        public IReadOnlyList<SimpleFieldAuditInfo> SimpleAudits => _simpleAudits.AsReadOnly();

        public IReadOnlyList<ComplexFieldAuditInfo> ComplexAudits => _complexAudits.AsReadOnly();

        public void AddSimpleAudit(string name, bool? oldValue, bool newValue)
        {
            AddSimpleAudit(name, oldValue.ToString(), newValue.ToString());
        }

        public void AddSimpleAudit(string name, string? oldValue, string? newValue)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            if (_simpleAudits.Any(a => a.Name == name))
            {
                throw new ArgumentException("Audit list already contains this field.", nameof(name));
            }

            if (newValue == oldValue)
            {
                return;
            }

            _simpleAudits.Add(new SimpleFieldAuditInfo(name, oldValue, newValue));
        }

        public void AddComplexAudit(string section, string summary, List<Guid> parentIds)
        {
            if (string.IsNullOrWhiteSpace(section))
            {
                throw new ArgumentException(nameof(section));
            }

            if (string.IsNullOrWhiteSpace(summary))
            {
                throw new ArgumentException(nameof(summary));
            }

            if (_complexAudits.Any(a => a.Section == section))
            {
                throw new ArgumentException("Audit list already contains this section.", nameof(section));
            }

            if (!parentIds.Any())
            {
                throw new ArgumentException(nameof(parentIds));
            }

            _complexAudits.Add(new ComplexFieldAuditInfo(section, summary, parentIds));
        }
    }

    public class SimpleFieldAuditInfo
    {
        public SimpleFieldAuditInfo(string name, string? oldValue, string? newValue)
        {
            Name = name;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public string Name
        {
            get; init;
        }

        public string? OldValue
        {
            get; init;
        }

        public string? NewValue
        {
            get; init;
        }
    }

    public class ComplexFieldAuditInfo
    {
        private List<Guid> _parentIds = new List<Guid>();

        public ComplexFieldAuditInfo(string section, string summary, List<Guid> parentIds)
        {
            Section = section;
            Summary = summary;
            _parentIds = parentIds;
        }

        public string Section
        {
            get; init;
        }

        public string Summary
        {
            get; init;
        }

        public IReadOnlyList<Guid> ParentIds => _parentIds.AsReadOnly();
    }
}
