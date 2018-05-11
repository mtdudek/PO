//////////////////////////////
//  Programowanie Obiektowe //
//  Maciej Tomasz Dudek     //
//  Nr. indeksu 299168      //
//  Pracownia 1             //
//  Zadanie 1-Figury        //
//////////////////////////////
#include <bits/stdc++.h>

using namespace std;

#define M_PI 3.14159265358979323846

enum typy_figur{    //Dodanie typu figury
    TROJKAT = 3,    //sprowadza sie do dodania
    KOLO = 1,       //jej nazwy i podania
    KWADRAT = 4     //ile ma miec wierzcholkow
};


typedef struct fig_t{
    typy_figur typfig;
    float   r,
            x[4],
            y[4];
} Figura;

float pole(Figura *f){
    float odp=0;
    if(f->typfig==1){
        return (float)M_PI*f->r*f->r;
    }
    else{
        for (int i=0;i<f->typfig;i++){
            int g=i+1;
            if(g==f->typfig)
                g=0;
            odp+=(f->x[i]*f->y[g]-f->x[g]*f->y[i]);
    }}
    return odp;
}

void przesun(Figura *f, float x,float y){
    for (int i=0;i<f->typfig;i++){
        f->x[i]+=x;
        f->y[i]+=y;
    }
}

float sumpol(Figura *f,int size){
    float odp=0;
    for(int i=0;i<size;i++)
        odp+= pole( &f[i] );
    return  odp;
}

int main(){
    int n;
    printf("Podaj liczbe figur:\n");
    scanf("%d",&n);
    if(n==0)
        return 0;
    printf("Najpier podaj typ figury: kolo - 1, trojkat - 2, kwadrat - 3,\n\
           \rpotem wspolrzedne jej wierzcholkow. W przypadku kola jego\n\
           \rsrodek i promien.\nPodaj figury:\n");
    Figura tab[n];
    for (int i=0;i<n;i++){
        int t;
        scanf("%d",&t);
        if(t==1){
            scanf("%f%f%f",&tab[i].x[0],&tab[i].y[0],&tab[i].r);
            tab[i].typfig=KOLO;
        }
        else{
            if(t==2){
                tab[i].typfig=TROJKAT;
                t=3;
            }
            else{
                tab[i].typfig=KWADRAT;
                t=4;
            }
            for (int j=0;j<t;j++)
                scanf("%f%f",&tab[i].x[j],&tab[i].y[j]);
        }
    }
    printf("Podaj liczbe operacji:\n");
    int h;
    scanf("%d",&h);
    if(h==0)
        return 0;
    printf("Najpier podaj typ operacji: 1-przesun o wektor 2-zsumuj pola\n\
           \r3 - zsumuj k pol od figury num i.\nJesli jest to\
           \rprzesuniecie, to podaj najpierw numer figury, potem wspolzedne wektora,\n\
           \rlub podaj liczbe figur, ktorych pola chcesz zsumowac, a potem ich numery\n\
           \rPodaj operacje:\n");

    for (int i=0;i<h;i++){
        int t;
        scanf("%d",&t);
        if(t==1){
            int fn;
            float a,b;
            scanf("%d%f%f",&fn,&a,&b);
            przesun(&tab[fn-1],a,b);
            printf("Nowe wspolrzedne:\n");
            if(tab[fn-1].typfig==1){
                printf("%f %f\n",tab[fn-1].x[0],tab[fn-1].y[0]);
            }
            else if(tab[fn-1].typfig==2){
                for (int j=0;j<3;j++){
                    printf("%f %f\n",tab[fn-1].x[j],tab[fn-1].y[j]);
                }
            }
            else {
                for (int j=0;j<4;j++){
                    printf("%f %f\n",tab[fn-1].x[j],tab[fn-1].y[j]);
                }
            }
        }
        else if(t==2){
            int l;
            float odp=0;
            scanf("%d",&l);
            for (int j=0;j<l;j++){
                int t2;
                scanf("%d",&t2);
                odp+=pole(&tab[t2-1]);
            }
            printf("Pole=%f\n",odp);
        }
        else{
            int pocz,liczba;
            scanf("%d%d",&pocz,&liczba);
            if(pocz+liczba-1>n)
                liczba=n-pocz+1;

            float odp;
            odp=sumpol(&tab[pocz-1],liczba);
            printf("Pola=%f\n",odp);
        }
    }

    return 0;
}
