import { Parcel } from "./parcel";

export interface Order{
    packageDto: Parcel,
    courierName: string,
    courierPrice: number,
    orderDate: Date
}