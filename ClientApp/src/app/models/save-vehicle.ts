import { Contact } from './contact';
import { KeyValuePair } from './key-value-pair';
export interface SaveVehicle {
    id: number;
    modelId: number;
    makeId: number;
    isRegistered: boolean;
    features: number[];
    contact: Contact;
}
