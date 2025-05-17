using Microsoft.EntityFrameworkCore;
using FlightTrack.Models;

namespace FlightTrack.Data;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

        if (await context.Airports.AnyAsync())
        {
            return; 
        }

        var airports = new List<Airport> //jib les airports men api 5ir
        {
            new Airport { Name = "John F. Kennedy International Airport", IataCode = "JFK", IcaoCode = "KJFK", City = "New York", Country = "United States", Latitude = 40.6413M, Longitude = -73.7781M },
            new Airport { Name = "Los Angeles International Airport", IataCode = "LAX", IcaoCode = "KLAX", City = "Los Angeles", Country = "United States", Latitude = 33.9416M, Longitude = -118.4085M },
            new Airport { Name = "O'Hare International Airport", IataCode = "ORD", IcaoCode = "KORD", City = "Chicago", Country = "United States", Latitude = 41.9786M, Longitude = -87.9048M },
            new Airport { Name = "San Francisco International Airport", IataCode = "SFO", IcaoCode = "KSFO", City = "San Francisco", Country = "United States", Latitude = 37.6188M, Longitude = -122.3750M },
            new Airport { Name = "Miami International Airport", IataCode = "MIA", IcaoCode = "KMIA", City = "Miami", Country = "United States", Latitude = 25.7932M, Longitude = -80.2906M },
            new Airport { Name = "Hartsfield-Jackson Atlanta International Airport", IataCode = "ATL", IcaoCode = "KATL", City = "Atlanta", Country = "United States", Latitude = 33.6367M, Longitude = -84.4281M },
            new Airport { Name = "Dallas/Fort Worth International Airport", IataCode = "DFW", IcaoCode = "KDFW", City = "Dallas", Country = "United States", Latitude = 32.8968M, Longitude = -97.0380M },
            new Airport { Name = "Denver International Airport", IataCode = "DEN", IcaoCode = "KDEN", City = "Denver", Country = "United States", Latitude = 39.8561M, Longitude = -104.6737M },
            new Airport { Name = "Seattle-Tacoma International Airport", IataCode = "SEA", IcaoCode = "KSEA", City = "Seattle", Country = "United States", Latitude = 47.4502M, Longitude = -122.3088M },
            new Airport { Name = "Las Vegas Harry Reid International Airport", IataCode = "LAS", IcaoCode = "KLAS", City = "Las Vegas", Country = "United States", Latitude = 36.0840M, Longitude = -115.1537M },
            new Airport { Name = "Phoenix Sky Harbor International Airport", IataCode = "PHX", IcaoCode = "KPHX", City = "Phoenix", Country = "United States", Latitude = 33.4484M, Longitude = -112.0740M },
            new Airport { Name = "George Bush Intercontinental Airport", IataCode = "IAH", IcaoCode = "KIAH", City = "Houston", Country = "United States", Latitude = 29.9902M, Longitude = -95.3368M },
            new Airport { Name = "Newark Liberty International Airport", IataCode = "EWR", IcaoCode = "KEWR", City = "Newark", Country = "United States", Latitude = 40.6895M, Longitude = -74.1745M },
            new Airport { Name = "Boston Logan International Airport", IataCode = "BOS", IcaoCode = "KBOS", City = "Boston", Country = "United States", Latitude = 42.3656M, Longitude = -71.0096M },
            new Airport { Name = "Detroit Metropolitan Wayne County Airport", IataCode = "DTW", IcaoCode = "KDTW", City = "Detroit", Country = "United States", Latitude = 42.2162M, Longitude = -83.3554M },

            new Airport { Name = "Toronto Pearson International Airport", IataCode = "YYZ", IcaoCode = "CYYZ", City = "Toronto", Country = "Canada", Latitude = 43.6777M, Longitude = -79.6248M },
            new Airport { Name = "Vancouver International Airport", IataCode = "YVR", IcaoCode = "CYVR", City = "Vancouver", Country = "Canada", Latitude = 49.1967M, Longitude = -123.1815M },
            new Airport { Name = "Montréal-Pierre Elliott Trudeau International Airport", IataCode = "YUL", IcaoCode = "CYUL", City = "Montreal", Country = "Canada", Latitude = 45.4706M, Longitude = -73.7408M },
            new Airport { Name = "Calgary International Airport", IataCode = "YYC", IcaoCode = "CYYC", City = "Calgary", Country = "Canada", Latitude = 51.1215M, Longitude = -114.0076M },
            new Airport { Name = "Edmonton International Airport", IataCode = "YEG", IcaoCode = "CYEG", City = "Edmonton", Country = "Canada", Latitude = 53.3097M, Longitude = -113.5792M },

            new Airport { Name = "Benito Juárez International Airport", IataCode = "MEX", IcaoCode = "MMMX", City = "Mexico City", Country = "Mexico", Latitude = 19.4363M, Longitude = -99.0721M },
            new Airport { Name = "Cancún International Airport", IataCode = "CUN", IcaoCode = "MMUN", City = "Cancun", Country = "Mexico", Latitude = 21.0365M, Longitude = -86.8771M },
            new Airport { Name = "Guadalajara International Airport", IataCode = "GDL", IcaoCode = "MMGL", City = "Guadalajara", Country = "Mexico", Latitude = 20.5218M, Longitude = -103.3111M },

            new Airport { Name = "London Heathrow Airport", IataCode = "LHR", IcaoCode = "EGLL", City = "London", Country = "United Kingdom", Latitude = 51.4700M, Longitude = -0.4543M },
            new Airport { Name = "London Gatwick Airport", IataCode = "LGW", IcaoCode = "EGKK", City = "London", Country = "United Kingdom", Latitude = 51.1537M, Longitude = -0.1821M },
            new Airport { Name = "Manchester Airport", IataCode = "MAN", IcaoCode = "EGCC", City = "Manchester", Country = "United Kingdom", Latitude = 53.3537M, Longitude = -2.2750M },
            new Airport { Name = "Paris Charles de Gaulle Airport", IataCode = "CDG", IcaoCode = "LFPG", City = "Paris", Country = "France", Latitude = 49.0097M, Longitude = 2.5478M },
            new Airport { Name = "Paris Orly Airport", IataCode = "ORY", IcaoCode = "LFPO", City = "Paris", Country = "France", Latitude = 48.7262M, Longitude = 2.3652M },
            new Airport { Name = "Nice Côte d'Azur Airport", IataCode = "NCE", IcaoCode = "LFMN", City = "Nice", Country = "France", Latitude = 43.6584M, Longitude = 7.2159M },
            new Airport { Name = "Amsterdam Airport Schiphol", IataCode = "AMS", IcaoCode = "EHAM", City = "Amsterdam", Country = "Netherlands", Latitude = 52.3086M, Longitude = 4.7639M },
            new Airport { Name = "Frankfurt Airport", IataCode = "FRA", IcaoCode = "EDDF", City = "Frankfurt", Country = "Germany", Latitude = 50.0379M, Longitude = 8.5622M },
            new Airport { Name = "Munich Airport", IataCode = "MUC", IcaoCode = "EDDM", City = "Munich", Country = "Germany", Latitude = 48.3538M, Longitude = 11.7861M },
            new Airport { Name = "Berlin Brandenburg Airport", IataCode = "BER", IcaoCode = "EDDB", City = "Berlin", Country = "Germany", Latitude = 52.3667M, Longitude = 13.5033M },
            new Airport { Name = "Madrid Barajas Airport", IataCode = "MAD", IcaoCode = "LEMD", City = "Madrid", Country = "Spain", Latitude = 40.4983M, Longitude = -3.5676M },
            new Airport { Name = "Barcelona El Prat Airport", IataCode = "BCN", IcaoCode = "LEBL", City = "Barcelona", Country = "Spain", Latitude = 41.2971M, Longitude = 2.0785M },
            new Airport { Name = "Rome Fiumicino Airport", IataCode = "FCO", IcaoCode = "LIRF", City = "Rome", Country = "Italy", Latitude = 41.8045M, Longitude = 12.2508M },
            new Airport { Name = "Milan Malpensa Airport", IataCode = "MXP", IcaoCode = "LIMC", City = "Milan", Country = "Italy", Latitude = 45.6306M, Longitude = 8.7281M },
            new Airport { Name = "Venice Marco Polo Airport", IataCode = "VCE", IcaoCode = "LIPZ", City = "Venice", Country = "Italy", Latitude = 45.5053M, Longitude = 12.3519M },
            new Airport { Name = "Zurich Airport", IataCode = "ZRH", IcaoCode = "LSZH", City = "Zurich", Country = "Switzerland", Latitude = 47.4582M, Longitude = 8.5555M },
            new Airport { Name = "Geneva Airport", IataCode = "GVA", IcaoCode = "LSGG", City = "Geneva", Country = "Switzerland", Latitude = 46.2370M, Longitude = 6.1091M },
            new Airport { Name = "Vienna International Airport", IataCode = "VIE", IcaoCode = "LOWW", City = "Vienna", Country = "Austria", Latitude = 48.1102M, Longitude = 16.5697M },
            new Airport { Name = "Copenhagen Airport", IataCode = "CPH", IcaoCode = "EKCH", City = "Copenhagen", Country = "Denmark", Latitude = 55.6180M, Longitude = 12.6508M },
            new Airport { Name = "Stockholm Arlanda Airport", IataCode = "ARN", IcaoCode = "ESSA", City = "Stockholm", Country = "Sweden", Latitude = 59.6519M, Longitude = 17.9186M },
            new Airport { Name = "Oslo Airport", IataCode = "OSL", IcaoCode = "ENGM", City = "Oslo", Country = "Norway", Latitude = 60.1975M, Longitude = 11.1004M },
            new Airport { Name = "Helsinki-Vantaa Airport", IataCode = "HEL", IcaoCode = "EFHK", City = "Helsinki", Country = "Finland", Latitude = 60.3172M, Longitude = 24.9633M },
            new Airport { Name = "Dublin Airport", IataCode = "DUB", IcaoCode = "EIDW", City = "Dublin", Country = "Ireland", Latitude = 53.4213M, Longitude = -6.2700M },
            new Airport { Name = "Lisbon Portela Airport", IataCode = "LIS", IcaoCode = "LPPT", City = "Lisbon", Country = "Portugal", Latitude = 38.7813M, Longitude = -9.1359M },
            new Airport { Name = "Athens International Airport", IataCode = "ATH", IcaoCode = "LGAV", City = "Athens", Country = "Greece", Latitude = 37.9364M, Longitude = 23.9445M },
            new Airport { Name = "Warsaw Chopin Airport", IataCode = "WAW", IcaoCode = "EPWA", City = "Warsaw", Country = "Poland", Latitude = 52.1657M, Longitude = 20.9671M },
            new Airport { Name = "Prague Václav Havel Airport", IataCode = "PRG", IcaoCode = "LKPR", City = "Prague", Country = "Czech Republic", Latitude = 50.1008M, Longitude = 14.2600M },
            new Airport { Name = "Budapest Ferenc Liszt International Airport", IataCode = "BUD", IcaoCode = "LHBP", City = "Budapest", Country = "Hungary", Latitude = 47.4298M, Longitude = 19.2611M },

            new Airport { Name = "Tokyo Haneda Airport", IataCode = "HND", IcaoCode = "RJTT", City = "Tokyo", Country = "Japan", Latitude = 35.5494M, Longitude = 139.7798M },
            new Airport { Name = "Tokyo Narita International Airport", IataCode = "NRT", IcaoCode = "RJAA", City = "Tokyo", Country = "Japan", Latitude = 35.7719M, Longitude = 140.3928M },
            new Airport { Name = "Osaka Kansai International Airport", IataCode = "KIX", IcaoCode = "RJBB", City = "Osaka", Country = "Japan", Latitude = 34.4320M, Longitude = 135.2440M },
            new Airport { Name = "Singapore Changi Airport", IataCode = "SIN", IcaoCode = "WSSS", City = "Singapore", Country = "Singapore", Latitude = 1.3644M, Longitude = 103.9915M },
            new Airport { Name = "Hong Kong International Airport", IataCode = "HKG", IcaoCode = "VHHH", City = "Hong Kong", Country = "China", Latitude = 22.3080M, Longitude = 113.9185M },
            new Airport { Name = "Beijing Capital International Airport", IataCode = "PEK", IcaoCode = "ZBAA", City = "Beijing", Country = "China", Latitude = 40.0799M, Longitude = 116.6031M },
            new Airport { Name = "Shanghai Pudong International Airport", IataCode = "PVG", IcaoCode = "ZSPD", City = "Shanghai", Country = "China", Latitude = 31.1443M, Longitude = 121.8083M },
            new Airport { Name = "Guangzhou Baiyun International Airport", IataCode = "CAN", IcaoCode = "ZGGG", City = "Guangzhou", Country = "China", Latitude = 23.3959M, Longitude = 113.3079M },
            new Airport { Name = "Dubai International Airport", IataCode = "DXB", IcaoCode = "OMDB", City = "Dubai", Country = "United Arab Emirates", Latitude = 25.2532M, Longitude = 55.3657M },
            new Airport { Name = "Abu Dhabi International Airport", IataCode = "AUH", IcaoCode = "OMAA", City = "Abu Dhabi", Country = "United Arab Emirates", Latitude = 24.4330M, Longitude = 54.6511M },
            new Airport { Name = "Doha Hamad International Airport", IataCode = "DOH", IcaoCode = "OTHH", City = "Doha", Country = "Qatar", Latitude = 25.2731M, Longitude = 51.6081M },
            new Airport { Name = "Incheon International Airport", IataCode = "ICN", IcaoCode = "RKSI", City = "Seoul", Country = "South Korea", Latitude = 37.4602M, Longitude = 126.4407M },
            new Airport { Name = "Taipei Taoyuan International Airport", IataCode = "TPE", IcaoCode = "RCTP", City = "Taipei", Country = "Taiwan", Latitude = 25.0777M, Longitude = 121.2322M },
            new Airport { Name = "Kuala Lumpur International Airport", IataCode = "KUL", IcaoCode = "WMKK", City = "Kuala Lumpur", Country = "Malaysia", Latitude = 2.7456M, Longitude = 101.7099M },
            new Airport { Name = "Bangkok Suvarnabhumi Airport", IataCode = "BKK", IcaoCode = "VTBS", City = "Bangkok", Country = "Thailand", Latitude = 13.6900M, Longitude = 100.7501M },
            new Airport { Name = "Indira Gandhi International Airport", IataCode = "DEL", IcaoCode = "VIDP", City = "Delhi", Country = "India", Latitude = 28.5562M, Longitude = 77.1000M },
            new Airport { Name = "Chhatrapati Shivaji Maharaj International Airport", IataCode = "BOM", IcaoCode = "VABB", City = "Mumbai", Country = "India", Latitude = 19.0896M, Longitude = 72.8656M },

            new Airport { Name = "Sydney Kingsford Smith Airport", IataCode = "SYD", IcaoCode = "YSSY", City = "Sydney", Country = "Australia", Latitude = -33.9399M, Longitude = 151.1753M },
            new Airport { Name = "Melbourne Airport", IataCode = "MEL", IcaoCode = "YMML", City = "Melbourne", Country = "Australia", Latitude = -37.6690M, Longitude = 144.8410M },
            new Airport { Name = "Brisbane Airport", IataCode = "BNE", IcaoCode = "YBBN", City = "Brisbane", Country = "Australia", Latitude = -27.3842M, Longitude = 153.1175M },
            new Airport { Name = "Perth Airport", IataCode = "PER", IcaoCode = "YPPH", City = "Perth", Country = "Australia", Latitude = -31.9385M, Longitude = 115.9674M },
            new Airport { Name = "Auckland Airport", IataCode = "AKL", IcaoCode = "NZAA", City = "Auckland", Country = "New Zealand", Latitude = -37.0082M, Longitude = 174.7850M },
            new Airport { Name = "Wellington International Airport", IataCode = "WLG", IcaoCode = "NZWN", City = "Wellington", Country = "New Zealand", Latitude = -41.3272M, Longitude = 174.8076M },
            new Airport { Name = "Christchurch International Airport", IataCode = "CHC", IcaoCode = "NZCH", City = "Christchurch", Country = "New Zealand", Latitude = -43.4894M, Longitude = 172.5320M },
            
            new Airport { Name = "São Paulo/Guarulhos International Airport", IataCode = "GRU", IcaoCode = "SBGR", City = "São Paulo", Country = "Brazil", Latitude = -23.4356M, Longitude = -46.4731M },
            new Airport { Name = "Rio de Janeiro/Galeão International Airport", IataCode = "GIG", IcaoCode = "SBGL", City = "Rio de Janeiro", Country = "Brazil", Latitude = -22.8089M, Longitude = -43.2436M },
            new Airport { Name = "Brasília International Airport", IataCode = "BSB", IcaoCode = "SBBR", City = "Brasília", Country = "Brazil", Latitude = -15.8711M, Longitude = -47.9186M },
            new Airport { Name = "Jorge Chávez International Airport", IataCode = "LIM", IcaoCode = "SPJC", City = "Lima", Country = "Peru", Latitude = -12.0219M, Longitude = -77.1143M },
            new Airport { Name = "El Dorado International Airport", IataCode = "BOG", IcaoCode = "SKBO", City = "Bogotá", Country = "Colombia", Latitude = 4.7016M, Longitude = -74.1469M },
            new Airport { Name = "Ministro Pistarini International Airport", IataCode = "EZE", IcaoCode = "SAEZ", City = "Buenos Aires", Country = "Argentina", Latitude = -34.8222M, Longitude = -58.5358M },
            new Airport { Name = "Arturo Merino Benítez International Airport", IataCode = "SCL", IcaoCode = "SCEL", City = "Santiago", Country = "Chile", Latitude = -33.3930M, Longitude = -70.7858M },
            new Airport { Name = "Simón Bolívar International Airport", IataCode = "CCS", IcaoCode = "SVMI", City = "Caracas", Country = "Venezuela", Latitude = 10.6031M, Longitude = -66.9910M },

            new Airport { Name = "OR Tambo International Airport", IataCode = "JNB", IcaoCode = "FAOR", City = "Johannesburg", Country = "South Africa", Latitude = -26.1367M, Longitude = 28.2425M },
            new Airport { Name = "Cape Town International Airport", IataCode = "CPT", IcaoCode = "FACT", City = "Cape Town", Country = "South Africa", Latitude = -33.9715M, Longitude = 18.6021M },
            new Airport { Name = "King Shaka International Airport", IataCode = "DUR", IcaoCode = "FALE", City = "Durban", Country = "South Africa", Latitude = -29.6144M, Longitude = 31.1197M },
            new Airport { Name = "Cairo International Airport", IataCode = "CAI", IcaoCode = "HECA", City = "Cairo", Country = "Egypt", Latitude = 30.1219M, Longitude = 31.4056M },
            new Airport { Name = "Hurghada International Airport", IataCode = "HRG", IcaoCode = "HEGN", City = "Hurghada", Country = "Egypt", Latitude = 27.1783M, Longitude = 33.7994M },
            new Airport { Name = "Mohammed V International Airport", IataCode = "CMN", IcaoCode = "GMMN", City = "Casablanca", Country = "Morocco", Latitude = 33.3675M, Longitude = -7.5897M },
            new Airport { Name = "Jomo Kenyatta International Airport", IataCode = "NBO", IcaoCode = "HKJK", City = "Nairobi", Country = "Kenya", Latitude = -1.3192M, Longitude = 36.9278M },
            new Airport { Name = "Addis Ababa Bole International Airport", IataCode = "ADD", IcaoCode = "HAAB", City = "Addis Ababa", Country = "Ethiopia", Latitude = 8.9778M, Longitude = 38.7989M },
            new Airport { Name = "Murtala Muhammed International Airport", IataCode = "LOS", IcaoCode = "DNMM", City = "Lagos", Country = "Nigeria", Latitude = 6.5774M, Longitude = 3.3216M },
            new Airport { Name = "Julius Nyerere International Airport", IataCode = "DAR", IcaoCode = "HTDA", City = "Dar es Salaam", Country = "Tanzania", Latitude = -6.8781M, Longitude = 39.2026M },

            new Airport { Name = "Minneapolis-Saint Paul International Airport", IataCode = "MSP", IcaoCode = "KMSP", City = "Minneapolis", Country = "United States", Latitude = 44.8820M, Longitude = -93.2218M },
            new Airport { Name = "Philadelphia International Airport", IataCode = "PHL", IcaoCode = "KPHL", City = "Philadelphia", Country = "United States", Latitude = 39.8744M, Longitude = -75.2424M },
            new Airport { Name = "Charlotte Douglas International Airport", IataCode = "CLT", IcaoCode = "KCLT", City = "Charlotte", Country = "United States", Latitude = 35.2141M, Longitude = -80.9431M },
            new Airport { Name = "Salt Lake City International Airport", IataCode = "SLC", IcaoCode = "KSLC", City = "Salt Lake City", Country = "United States", Latitude = 40.7899M, Longitude = -111.9791M },
            new Airport { Name = "Orlando International Airport", IataCode = "MCO", IcaoCode = "KMCO", City = "Orlando", Country = "United States", Latitude = 28.4294M, Longitude = -81.3089M },
            new Airport { Name = "Washington Dulles International Airport", IataCode = "IAD", IcaoCode = "KIAD", City = "Washington", Country = "United States", Latitude = 38.9445M, Longitude = -77.4558M },
            new Airport { Name = "Ronald Reagan Washington National Airport", IataCode = "DCA", IcaoCode = "KDCA", City = "Washington", Country = "United States", Latitude = 38.8521M, Longitude = -77.0377M },
            new Airport { Name = "San Diego International Airport", IataCode = "SAN", IcaoCode = "KSAN", City = "San Diego", Country = "United States", Latitude = 32.7336M, Longitude = -117.1897M },
            new Airport { Name = "Portland International Airport", IataCode = "PDX", IcaoCode = "KPDX", City = "Portland", Country = "United States", Latitude = 45.5898M, Longitude = -122.5951M },
            new Airport { Name = "Baltimore/Washington International Airport", IataCode = "BWI", IcaoCode = "KBWI", City = "Baltimore", Country = "United States", Latitude = 39.1754M, Longitude = -76.6682M },

            new Airport { Name = "Ottawa Macdonald-Cartier International Airport", IataCode = "YOW", IcaoCode = "CYOW", City = "Ottawa", Country = "Canada", Latitude = 45.3225M, Longitude = -75.6692M },
            new Airport { Name = "Halifax Stanfield International Airport", IataCode = "YHZ", IcaoCode = "CYHZ", City = "Halifax", Country = "Canada", Latitude = 44.8808M, Longitude = -63.5085M },
            new Airport { Name = "Québec City Jean Lesage International Airport", IataCode = "YQB", IcaoCode = "CYQB", City = "Quebec City", Country = "Canada", Latitude = 46.7911M, Longitude = -71.3933M },
            new Airport { Name = "Winnipeg James Armstrong Richardson International Airport", IataCode = "YWG", IcaoCode = "CYWG", City = "Winnipeg", Country = "Canada", Latitude = 49.9100M, Longitude = -97.2399M },

            new Airport { Name = "Monterrey International Airport", IataCode = "MTY", IcaoCode = "MMMY", City = "Monterrey", Country = "Mexico", Latitude = 25.7785M, Longitude = -100.1067M },
            new Airport { Name = "Los Cabos International Airport", IataCode = "SJD", IcaoCode = "MMSD", City = "San José del Cabo", Country = "Mexico", Latitude = 23.1518M, Longitude = -109.7215M },
            new Airport { Name = "Puerto Vallarta International Airport", IataCode = "PVR", IcaoCode = "MMPR", City = "Puerto Vallarta", Country = "Mexico", Latitude = 20.6801M, Longitude = -105.2544M },

            new Airport { Name = "Brussels Airport", IataCode = "BRU", IcaoCode = "EBBR", City = "Brussels", Country = "Belgium", Latitude = 50.9014M, Longitude = 4.4844M },
            new Airport { Name = "Milan Linate Airport", IataCode = "LIN", IcaoCode = "LIML", City = "Milan", Country = "Italy", Latitude = 45.4507M, Longitude = 9.2777M },
            new Airport { Name = "Naples International Airport", IataCode = "NAP", IcaoCode = "LIRN", City = "Naples", Country = "Italy", Latitude = 40.8847M, Longitude = 14.2908M },
            new Airport { Name = "Edinburgh Airport", IataCode = "EDI", IcaoCode = "EGPH", City = "Edinburgh", Country = "United Kingdom", Latitude = 55.9500M, Longitude = -3.3725M },
            new Airport { Name = "Glasgow Airport", IataCode = "GLA", IcaoCode = "EGPF", City = "Glasgow", Country = "United Kingdom", Latitude = 55.8717M, Longitude = -4.4333M },
            new Airport { Name = "Lyon-Saint Exupéry Airport", IataCode = "LYS", IcaoCode = "LFLL", City = "Lyon", Country = "France", Latitude = 45.7256M, Longitude = 5.0811M },
            new Airport { Name = "Marseille Provence Airport", IataCode = "MRS", IcaoCode = "LFML", City = "Marseille", Country = "France", Latitude = 43.4392M, Longitude = 5.2214M },
            new Airport { Name = "Hamburg Airport", IataCode = "HAM", IcaoCode = "EDDH", City = "Hamburg", Country = "Germany", Latitude = 53.6304M, Longitude = 9.9882M },
            new Airport { Name = "Stuttgart Airport", IataCode = "STR", IcaoCode = "EDDS", City = "Stuttgart", Country = "Germany", Latitude = 48.6899M, Longitude = 9.2220M },
            new Airport { Name = "Düsseldorf Airport", IataCode = "DUS", IcaoCode = "EDDL", City = "Düsseldorf", Country = "Germany", Latitude = 51.2895M, Longitude = 6.7668M },

            new Airport { Name = "Sapporo New Chitose Airport", IataCode = "CTS", IcaoCode = "RJCC", City = "Sapporo", Country = "Japan", Latitude = 42.7752M, Longitude = 141.6922M },
            new Airport { Name = "Fukuoka Airport", IataCode = "FUK", IcaoCode = "RJFF", City = "Fukuoka", Country = "Japan", Latitude = 33.5858M, Longitude = 130.4511M },
            new Airport { Name = "Shenzhen Bao'an International Airport", IataCode = "SZX", IcaoCode = "ZGSZ", City = "Shenzhen", Country = "China", Latitude = 22.6395M, Longitude = 113.8145M },
            new Airport { Name = "Chengdu Shuangliu International Airport", IataCode = "CTU", IcaoCode = "ZUUU", City = "Chengdu", Country = "China", Latitude = 30.5785M, Longitude = 103.9471M },
            new Airport { Name = "Jeju International Airport", IataCode = "CJU", IcaoCode = "RKPC", City = "Jeju", Country = "South Korea", Latitude = 33.5113M, Longitude = 126.4930M },
            new Airport { Name = "Gimpo International Airport", IataCode = "GMP", IcaoCode = "RKSS", City = "Seoul", Country = "South Korea", Latitude = 37.5586M, Longitude = 126.7944M },
            new Airport { Name = "Hanoi Noi Bai International Airport", IataCode = "HAN", IcaoCode = "VVNB", City = "Hanoi", Country = "Vietnam", Latitude = 21.2187M, Longitude = 105.8019M },
            new Airport { Name = "Tan Son Nhat International Airport", IataCode = "SGN", IcaoCode = "VVTS", City = "Ho Chi Minh City", Country = "Vietnam", Latitude = 10.8188M, Longitude = 106.6520M },
            new Airport { Name = "Manila Ninoy Aquino International Airport", IataCode = "MNL", IcaoCode = "RPLL", City = "Manila", Country = "Philippines", Latitude = 14.5086M, Longitude = 121.0194M },
            new Airport { Name = "Mactan-Cebu International Airport", IataCode = "CEB", IcaoCode = "RPVM", City = "Cebu", Country = "Philippines", Latitude = 10.3075M, Longitude = 123.9792M },

            new Airport { Name = "Adelaide Airport", IataCode = "ADL", IcaoCode = "YPAD", City = "Adelaide", Country = "Australia", Latitude = -34.9450M, Longitude = 138.5306M },
            new Airport { Name = "Gold Coast Airport", IataCode = "OOL", IcaoCode = "YBCG", City = "Gold Coast", Country = "Australia", Latitude = -28.1644M, Longitude = 153.5047M },
            new Airport { Name = "Cairns Airport", IataCode = "CNS", IcaoCode = "YBCS", City = "Cairns", Country = "Australia", Latitude = -16.8858M, Longitude = 145.7555M },
            new Airport { Name = "Darwin International Airport", IataCode = "DRW", IcaoCode = "YPDN", City = "Darwin", Country = "Australia", Latitude = -12.4147M, Longitude = 130.8772M },
            new Airport { Name = "Queenstown Airport", IataCode = "ZQN", IcaoCode = "NZQN", City = "Queenstown", Country = "New Zealand", Latitude = -45.0211M, Longitude = 168.7392M },

            new Airport { Name = "Salvador International Airport", IataCode = "SSA", IcaoCode = "SBSV", City = "Salvador", Country = "Brazil", Latitude = -12.9086M, Longitude = -38.3225M },
            new Airport { Name = "Recife/Guararapes International Airport", IataCode = "REC", IcaoCode = "SBRF", City = "Recife", Country = "Brazil", Latitude = -8.1264M, Longitude = -34.9236M },
            new Airport { Name = "Mariscal Sucre International Airport", IataCode = "UIO", IcaoCode = "SEQM", City = "Quito", Country = "Ecuador", Latitude = -0.1292M, Longitude = -78.3575M },
            new Airport { Name = "José Joaquín de Olmedo International Airport", IataCode = "GYE", IcaoCode = "SEGU", City = "Guayaquil", Country = "Ecuador", Latitude = -2.1574M, Longitude = -79.8837M },
            new Airport { Name = "Asunción Silvio Pettirossi International Airport", IataCode = "ASU", IcaoCode = "SGAS", City = "Asunción", Country = "Paraguay", Latitude = -25.2402M, Longitude = -57.5197M },

            new Airport { Name = "Houari Boumediene Airport", IataCode = "ALG", IcaoCode = "DAAG", City = "Algiers", Country = "Algeria", Latitude = 36.6910M, Longitude = 3.2153M },
            new Airport { Name = "Tunis-Carthage International Airport", IataCode = "TUN", IcaoCode = "DTTA", City = "Tunis", Country = "Tunisia", Latitude = 36.8515M, Longitude = 10.2272M },
            new Airport { Name = "Khartoum International Airport", IataCode = "KRT", IcaoCode = "HSSS", City = "Khartoum", Country = "Sudan", Latitude = 15.5895M, Longitude = 32.5532M },
            new Airport { Name = "Roland Garros Airport", IataCode = "RUN", IcaoCode = "FMEE", City = "Saint-Denis", Country = "Réunion", Latitude = -20.8871M, Longitude = 55.5103M }
        };

        // put airports in context
        await context.Airports.AddRangeAsync(airports);
        
        await context.SaveChangesAsync();
    }
} 