/*Calculator named by me: W E R L Y N */

import { FecthUSDNIORate } from "./FetchingInfo";

function getDateToday(){
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();
    today = yyyy + '-' + mm + '-' + dd;
    return today;
}
  
function isTheSameDay(date1, date2){
    if(date1.getFullYear() === date2.getFullYear() && date1.getMonth() === date2.getMonth() && date1.getDate() === date2.getDate()){
        return true;
    }else{
        return false;
    }
}
  
  /*Currency */
function getRateUSDNIO(){
    var CR = localStorage.getItem('convertRate');
    const latestUpdated = localStorage.getItem('latestRateUpdated');
    const today = getDateToday();

    if(CR!=null || latestUpdated!=null){
        if (isTheSameDay(new Date(latestUpdated), new Date(today))) {
        return CR;
        }
    }
    FecthUSDNIORate().then((result)=>{
        CR = result;
    })
    return CR;
}

export const RateUSDNIO = getRateUSDNIO();

/*Cordoba to USD */
export function NIOConvUSD(NIO){
    return parseFloat(Number(NIO/RateUSDNIO).toFixed(2))
}

/*USD to Cordoba */
export function USDConvNIO(USD){
    return parseFloat(Number(USD*RateUSDNIO).toFixed(2))
}