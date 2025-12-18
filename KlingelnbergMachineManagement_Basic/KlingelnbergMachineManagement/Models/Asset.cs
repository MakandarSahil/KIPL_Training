namespace KlingelnbergMachineManagement.Domain.Models
{
    // assets with name and series number
    // an asset has a name which belongs to a series
    public class Asset
    {
        public string Name { get; set; }
        public string SeriesNumber { get; set; }

        public Asset(string name, string seriesNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            SeriesNumber = seriesNumber ?? throw new ArgumentNullException(nameof(seriesNumber));
        }

        // extract numeric part from series to check latest 
        // S6 -> returns 6
        public int GetSeriesNumericValue()
        {
            if (string.IsNullOrWhiteSpace(SeriesNumber) || !SeriesNumber.StartsWith("S"))
                throw new InvalidOperationException($"Invalid Series Number Format {SeriesNumber}");

            var numericPart = SeriesNumber.Substring(1);

            if (int.TryParse(numericPart, out int value))
                return value;

            throw new InvalidOperationException($"Cannot parse series number : {SeriesNumber}");
            
        }

        // check if two assets are equal 
        // default equal checks if refrence pointing to the same object in memory
        // we check if we have same name and series number 

        // ovveriding becuase we need to change equality meaning for this object to the entire runtime
        public override bool Equals(object? obj)
        {
            
            if(obj is Asset other)
                return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase) && 
                    SeriesNumber.Equals(other.SeriesNumber, StringComparison.OrdinalIgnoreCase);

            return false;
        }

        // if two objects are equal then they must return same hashcode 
        // if hash matches then Equals get called
        // its must to ovveride GetHashCode() if we ovveride Equals() becuase hash code need to be same

        public override int GetHashCode()
        {
            return HashCode.Combine(
                    Name.ToLowerInvariant(),
                    SeriesNumber.ToLowerInvariant()
                   );
        }

        public override string ToString()
        {
            return $"{Name} ({SeriesNumber})";
        }
    }
}