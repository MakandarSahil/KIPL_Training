namespace KlingelnbergMachineManagement.Domain.Models
{
    // to reprent a machine with its type/name 
    // a machine owns muliple assets 
    public class Machine
    { 
        public string Type {  get; set; }
        public List<Asset> Assets { get; set; }

        public Machine(string machineType)
        {
            Type = machineType ?? throw new ArgumentNullException(nameof(machineType));
            Assets = new List<Asset>();
        }


        // add asset to the machine
        public void AddAsset(Asset asset)
        {
            if(asset == null)
                throw new ArgumentNullException(nameof(asset));

            Assets.Add(asset);
        }

        
        public override bool Equals(object? obj)
        {
            if (obj is Machine other)
                return Type.Equals(other.Type, StringComparison.OrdinalIgnoreCase);

            return false;
        }

        public override int GetHashCode()
        {
            return Type.ToLowerInvariant().GetHashCode();
        }

        public override string ToString()
        {
            return $"{Type} (Assets : {Assets.Count})";
        }
    }
}