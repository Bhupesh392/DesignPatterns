public class Company
{

    public int ID;
    public CompanyDescription desc;

    public Company(int id, string c,
                               string o)
    {
        this.ID = id;
        desc = new CompanyDescription(c, o);
    }

    // method for cloning object
    public object Shallowcopy()
    {
        return this.MemberwiseClone();
    }

    // method for cloning object
    public Company DeepCopy()
    {
        Company deepcopyCompany = new Company(this.ID,
                            desc.CompanyName, desc.Owner);
        return deepcopyCompany;
    }
}
public class CompanyDescription
{

    public string CompanyName;
    public string Owner;
    public CompanyDescription(string c, string o)
    {
        this.CompanyName = c;
        this.Owner = o;
    }
}