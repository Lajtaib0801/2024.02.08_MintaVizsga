using RealEstate;

List<Ad> adList = Ad.LoadFromJson("realestates.json");
Console.WriteLine($"1. Földszinti ingatlanok átlagos alapterülete: {Ad.GetAverage(adList):f2} m2");
var minEstate = Ad.GetClosest(adList, 47.4164220114023, 19.066342425796986);
Console.WriteLine("A Mesevár óvodához legvonalban legközelebbi tehrementes ingatlan adatai:");
Console.WriteLine($"\tEladó neve\t: {minEstate.seller.name}");
Console.WriteLine($"\tEladó telefonja\t: {minEstate.seller.phone}");
Console.WriteLine($"\tAlapterület\t: {minEstate.area}");
Console.WriteLine($"\tSzobák száma\t: {minEstate.rooms}");
