import { IMaterialType } from "./matrialType"
import { IMaster } from "./master"
import { IProductType } from "./productType"
import { IClientList } from "./clientList"

// export interface IAdditionalData{
//     data:Array<Array<{x:IMaterialType,y:IMaster,z:IProductType}>>
//     // materials:IMaterialType[];
//     // masters:IMaster[];
//     // products:IProductType[];
// }

export type IAdditionalData = [IMaterialType[], IMaster[], IProductType[], IClientList[]]