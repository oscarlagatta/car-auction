'use server';

import {Auction, PagedResults} from "@/types";
import {auth} from "@/auth";

export async function getData(query: string): Promise<PagedResults<Auction>> {
    const res = await fetch(`http://localhost:6001/search${query}`);
    if (!res.ok) {
        throw new Error('Failed to fetch data.');
    }
    return res.json();
}

export async function updateActionTest() {
    const data = {
        mileage: Math.floor(Math.random() * 10000) + 1
    }

    const session = await auth();

    const res = await fetch(`http://localhost:6001/auctions/afbee524-5972-4075-8800-7d1f9d7b0a0c`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${session?.accessToken}`
        },
        body: JSON.stringify(data),
    });

    if (!res.ok) {
        return {
            status: res.status, message: res.statusText
        }
    }

    return res.statusText;
}