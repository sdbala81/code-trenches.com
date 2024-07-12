using FluentBuilderPattern.Models;

namespace FluentBuilderPattern.Builder;

public class ShippingAddressBuilder
{
    private string _no;
    private string _streetName;
    private string _city;
    private string _county;
    private string _country;

    public ShippingAddressBuilder WithNo(string no)
    {
        _no = no;
        return this;
    }

    public ShippingAddressBuilder WithStreetName(string streetName)
    {
        _streetName = streetName;
        return this;
    }

    public ShippingAddressBuilder WithCity(string city)
    {
        _city = city;
        return this;
    }

    public ShippingAddressBuilder WithCounty(string county)
    {
        _county = county;
        return this;
    }

    public ShippingAddressBuilder WithCountry(string country)
    {
        _country = country;
        return this;
    }

    public Address Build()
    {
        return new Address
        {
            No = _no,
            StreetName = _streetName,
            City = _city,
            County = _county,
            Country = _country
        };
    }
}
