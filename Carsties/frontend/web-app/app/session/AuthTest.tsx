'use client';

import {useState} from "react";
import {updateActionTest} from "@/app/actions/auctionActions";
import {Button} from "flowbite-react";

export function AuthTest() {

    const [loading, setLoading] = useState(false);
    const [result, setResult] = useState<any>();

    function doUpdate() {
        setResult(undefined);
        setLoading(true);

        updateActionTest()
            .then(res=>setResult(res))
            .catch(err => setResult(err))
            .finally(()=>setLoading(false));
    }
    return (
        <div className="flex items-center gap-4">
            <Button outline isProcessing={loading} onClick={doUpdate}>Test Auth</Button>

            <div>
                {JSON.stringify(result, null, 2)}
            </div>
        </div>
    );
}
