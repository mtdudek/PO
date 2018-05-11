//////////////////////////////
//  Programowanie Obiektowe //
//  Maciej Tomasz Dudek     //
//  Nr. indeksu 299168      //
//  Pracownia 1             //
//  Zadanie 2-ulamki        //
//////////////////////////////
#include <bits/stdc++.h>

using namespace std;

int64_t GCD(int64_t a,int64_t b){
    if(a==0)
        return b;
    return GCD(b%a,a);
}

int64_t LCM(int64_t a,int64_t b){
    return (a/GCD(a,b))*b;
}

typedef struct ulamki_t{
    int64_t licz,mian;
} ulamki;

void normalizuj(ulamki *a){
    if(a->mian>0) return;
    if(a->mian<0){
        a->licz*=(-1LL);
        a->mian*=(-1LL);
    }
}

void normalizuj(ulamki &a){
    if(a.mian>0) return;
    if(a.mian<0){
        a.licz*=(-1LL);
        a.mian*=(-1LL);
    }
}

ulamki *dod1(ulamki A,ulamki B){
    ulamki *odp;
    odp=new ulamki;
    int64_t temp=LCM(A.mian,B.mian);
    odp->mian=temp;
    odp->licz=(A.licz*(temp/A.mian))+(B.licz*(temp/B.mian));
    int64_t k=GCD(odp->licz,odp->mian);
    odp->mian/=k;odp->licz/=k;
    normalizuj(odp);
    return odp;
}

ulamki *ode1(ulamki A,ulamki B){
    B.licz*=(-1LL);
    return dod1(A,B);
}

ulamki *mno1(ulamki A,ulamki B){
    ulamki *odp;
    odp=new ulamki;
    int64_t t1=GCD(A.licz,B.mian),t2=GCD(A.mian,B.licz),t3;
    A.licz/=t1;B.mian/=t1;
    A.mian/=t2;B.licz/=t2;
    odp->licz=(A.licz*B.licz);
    odp->mian=(A.mian*B.mian);
    t3=GCD(odp->licz,odp->mian);
    odp->licz/=t3;odp->mian/=t3;
    normalizuj(odp);
    return odp;
}

ulamki *dzi1(ulamki A,ulamki B){
    if(B.licz==0){
        throw invalid_argument("DZIELENIE PRZEZ 0\n");
    }
    swap(B.licz,B.mian);
    return mno1(A,B);
}

void dod2(ulamki A,ulamki &B){
    int64_t temp=LCM(A.mian,B.mian);
    B.licz*=(temp/B.mian); B.mian*=(temp/B.mian);
    A.licz*=(temp/A.mian); A.mian*=(temp/A.mian);
    B.licz+=A.licz;
    int64_t k=abs(GCD(B.licz,B.mian));
    B.licz/=k; B.mian/=k;
    normalizuj(B);
}

void ode2(ulamki A,ulamki &B){
    B.licz*=(-1LL);
    dod2(A,B);
}

void mno2(ulamki A,ulamki &B){
    int64_t t1=GCD(A.licz,B.mian),t2=GCD(A.mian,B.licz),t3;
    A.licz/=t1;B.mian/=t1;
    A.mian/=t2;B.licz/=t2;
    B.licz*=A.licz;
    B.mian*=A.mian;
    t3=GCD(B.licz,B.mian);
    B.licz/=t3;B.mian/=t3;
    normalizuj(B);
}

void dzi2(ulamki A,ulamki &B){
    if(B.licz==0){
        throw invalid_argument("DZIELENIE PRZEZ 0\n");
    }
    swap(B.licz,B.mian);
    mno2(A,B);
}

int main(){
    ulamki q1,q2,qt,*h;
    printf("Podaj dwa u³amki.\n W pierwsze dwie liczby\
           \rbada stanowily licznik i mianownik pierwszego ulamka,\n\
           \rnatomiast kolejne dwie liczby icznik i mianownik wlamka drugiego.\n");
    scanf("%lld %lld %lld %lld",&q1.licz,&q1.mian,&q2.licz,&q2.mian);
    if(q1.mian==0||q2.mian==0){
        printf("DZIELENIE PRZEZ 0");
        return 0;
    }
    h=dod1(q1,q2);
    printf("Wynik dodawania pierwsza metoda %lld %lld\n",h->licz,h->mian);
    h=ode1(q1,q2);
    printf("Wynik odejmowania pierwsza metoda %lld %lld\n",h->licz,h->mian);
    h=mno1(q1,q2);
    printf("Wynik mnozenia pierwsza metoda %lld %lld\n",h->licz,h->mian);
    try{
        h=dzi1(q1,q2);
        printf("Wynik dzielenia pierwsza metoda %lld %lld\n",h->licz,h->mian);
    }
    catch (const invalid_argument &ia){
        cerr<<"ZLE DANE:"<<ia.what();
    }
    qt=q2;
    dod2(q1,qt);
    printf("Wynik dodawania druga metoda %lld %lld\n",qt.licz,qt.mian);
    qt=q2;
    ode2(q1,qt);
    printf("Wynik odejmowania druga metoda %lld %lld\n",qt.licz,qt.mian);
    qt=q2;
    mno2(q1,qt);
    printf("Wynik mnozenia druga metoda %lld %lld\n",qt.licz,qt.mian);
    qt=q2;
    try{
        dzi2(q1,qt);
        printf("Wynik dzielenia druga metoda %lld %lld\n",qt.licz,qt.mian);
    }
    catch (const invalid_argument &ia){
        cerr<<"ZLE DANE:"<<ia.what();
    }
    return 0;
}
