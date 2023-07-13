export class Utils{
    static SetCurrencyFactor(id:string):number{
        switch(id){
            case 'USD':
                return 1;
            case 'COP':
                return 4150;
            case 'EUR':
                return 0.89;
            case 'GBP':
                return 0.76;
            default:
                return 1;            
        }
    }
}