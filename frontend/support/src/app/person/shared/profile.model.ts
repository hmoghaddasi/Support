export class ProfileModel {
    public PersonId: number;
    public FirstName: string;
    public LastName: string;
    public LoginName: string;
    public Email: string;
    public Gender: boolean;
    public Mobile: string;
    public Site: string;
    public Phone: string;
    public PassKey: string;
    public PersonTypeId: number;
    public StatusId: number;
    public GroupId: number;
    public CategoryId: number;
    public FullName: string;
    public GenderTxt: string;
    public Status: string;
    public StatusClass: string;
    public PharmacyName: string;
    public CityName: string;
    public RequestItems: ProfileRequestItem[];
    public ResponseItems: ResponseItems[];
    public CreditItems: ProfileCreditItem[];
}

export class ProfileRequestItem {
    public Status: string;
    public Count: number;
}

export class ResponseItems {
    public Status: string;
    public Count: number;
}
export class ProfileCreditItem {
    public Title: string;
    public DurationDays: number;
    public Price: number;
    public PersianPurchaseDate: string;
    public PersianStartDate: string;
    public PersianEndDate: string;
}