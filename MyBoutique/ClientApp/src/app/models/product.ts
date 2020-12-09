export class Product {
    id: number;
    name: string;
    description: string;
    price: number;
    categoryName: string;
    categoryType: string;
    sizes: Array<string>;
    colors: Array<string>;
    createdOn: Date;
}