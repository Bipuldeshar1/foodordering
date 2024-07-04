export class UserModel {
    constructor(
        public name: string,
        public email: string,
        public password: string,
        public phoneNumber: string,
        public address: string
    ) {}
}
