export class LoginRequestModel {
    
    private _userName : string;
    public get userName() : string {
        return this._userName;
    }
    public set userName(v : string) {
        this._userName = v;
    }
    
    private _password : string;
    public get password() : string {
        return this._password;
    }
    public set password(v : string) {
        this._password = v;
    }
    
    
}
