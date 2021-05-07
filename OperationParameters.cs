using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtyModel.Model
{
    public class OperationParameters
    {
        private bool hasBaseChanges;
        private bool hasAlbumChanges;
        private bool hasCustomerChanges;
        private bool hasLocationChanges;
        private TargetType target;
        private OperationType type;
        private OperationDirection direction;

        public bool HasBaseChanges {
            get => hasBaseChanges;
            set => hasBaseChanges = value;
        }
        public bool HasAlbumChanges {
            get => hasAlbumChanges;
            set => hasAlbumChanges = value;
        }
        public bool HasCustomerChanges {
            get => hasCustomerChanges;
            set => hasCustomerChanges = value;
        }
        public bool HasLocationChanges {
            get => hasLocationChanges;
            set => hasLocationChanges = value;
        }
        public TargetType Target {
            get => target;
            set => target = value;
        }
        public OperationType Type {
            get => type;
            set => type = value;
        }
        public OperationDirection Direction {
            get => direction;
            set => direction = value;
        }

        public OperationParameters() { }
        public OperationParameters(OperationDirection direction, OperationType type, TargetType target)
        {
            this.direction = direction;
            this.type = type;
            this.target = target;
        }
    }
}
