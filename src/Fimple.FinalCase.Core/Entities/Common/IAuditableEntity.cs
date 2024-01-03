namespace Fimple.FinalCase.Core.Entities.Common;

public interface IAuditableEntity<TId>
    {
        public DateTime CreatedAt { get; set; }

        public TId CreatedBy { get; set; }

        public TId? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }